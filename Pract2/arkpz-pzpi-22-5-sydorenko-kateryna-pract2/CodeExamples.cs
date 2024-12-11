// Introduce parameter object

// BAD EXAMPLE
public async Task<(List<TestActivityDTO>, int)> GetUserActivityTests(
    int userId, 
    Visibility? filterParam = null, 
    int pageNumber = 1, 
    int pageSize = 6, 
    string orderByProp = "test_id", 
    string sortOrder = "asc", 
    string serachParam = null)
{
    string sqlExpression = "PagingActivity";

    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        List<TestActivityDTO> tests = new();
        int totalRecords = 0;
        bool IsNextPageAvailable;

        using (SqlCommand command = new SqlCommand(sqlExpression, connection))
        {
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@PageNumber", pageNumber);
            command.Parameters.AddWithValue("@PageSize", pageSize);
            command.Parameters.AddWithValue("@OrderBy", orderByProp);
            command.Parameters.AddWithValue("@SortOrder", sortOrder);
            command.Parameters.AddWithValue("@UserId", userId);
            command.Parameters.AddWithValue("@FilterParam", filterParam != null ? filterParam : DBNull.Value);
            command.Parameters.AddWithValue("@SearchParam", !string.IsNullOrEmpty(serachParam) ? serachParam : DBNull.Value);

            SqlParameter totalRecordsParam = new SqlParameter("@TotalRecords", SqlDbType.Int);
            totalRecordsParam.Direction = ParameterDirection.Output;
            command.Parameters.Add(totalRecordsParam);

            connection.Open();

            SqlDataReader reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                reader.Read();
                totalRecords = (int)reader["TotalRecords"];
            }
            reader.NextResult();
            var columns = reader.GetColumnSchema();

            while (reader.Read())
            {
                TestActivityDTO test = new();
                test.TestId = (int)reader["test_id"];
                test.Name = (string)reader["test_name"];
                test.Description = (string)reader["test_description"];
                test.Visibility = (Visibility)reader["test_visibility"];
                test.LastAttemptDate = (DateTime)reader["last_attempt_date"];
                test.AttemptsAmount = (int)reader["attempts_count"];
                tests.Add(test);
            }
        }

        return (tests, totalRecords);
    }
}

// GOOD EXAMPLE
public class ActivityTestQueryParameters
{
    public int UserId { get; set; }
    public Visibility? FilterParam { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 6;
    public string OrderByProp { get; set; } = "test_id";
    public string SortOrder { get; set; } = "asc";
    public string SearchParam { get; set; } = null;
}

public async Task<(List<TestActivityDTO>, int)> GetUserActivityTests(ActivityTestQueryParameters queryParams)
{
    string sqlExpression = "PagingActivity";

    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        List<TestActivityDTO> tests = new();
        int totalRecords = 0;

        using (SqlCommand command = new SqlCommand(sqlExpression, connection))
        {
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@PageNumber", queryParams.PageNumber);
            command.Parameters.AddWithValue("@PageSize", queryParams.PageSize);
            command.Parameters.AddWithValue("@OrderBy", queryParams.OrderByProp);
            command.Parameters.AddWithValue("@SortOrder", queryParams.SortOrder);
            command.Parameters.AddWithValue("@UserId", queryParams.UserId);
            command.Parameters.AddWithValue("@FilterParam", queryParams.FilterParam ?? DBNull.Value);
            command.Parameters.AddWithValue("@SearchParam", !string.IsNullOrEmpty(queryParams.SearchParam) ? queryParams.SearchParam : DBNull.Value);

            SqlParameter totalRecordsParam = new SqlParameter("@TotalRecords", SqlDbType.Int);
            totalRecordsParam.Direction = ParameterDirection.Output;
            command.Parameters.Add(totalRecordsParam);

            connection.Open();
            SqlDataReader reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                reader.Read();
                totalRecords = (int)reader["TotalRecords"];
            }

            reader.NextResult();

            while (reader.Read())
            {
                TestActivityDTO test = new()
                {
                    TestId = (int)reader["test_id"],
                    Name = (string)reader["test_name"],
                    Description = (string)reader["test_description"],
                    Visibility = (Visibility)reader["test_visibility"],
                    LastAttemptDate = (DateTime)reader["last_attempt_date"],
                    AttemptsAmount = (int)reader["attempts_count"]
                };
                tests.Add(test);
            }
        }

        return (tests, totalRecords);
    }
}


// Hide Delegate 

// BAD EXAMPLES
public async Task<Result<bool>> EnrollMemberToClass(Enrollment enrollment, CancellationToken ct)
{
    var query = @"INSERT INTO Enrollment (class_id, member_id, enrollment_date) 
                  VALUES (@ClassId, @MemberId, @EnrollmentDate);
                  SELECT SCOPE_IDENTITY();";

    try
    {
        // Directly creating and managing the connection
        var connectionString = "YourDatabaseConnectionString";
        using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync(ct);

        var isMemberExists = await _memberRepository.IsExists(enrollment.MemberId, ct);
        if (!isMemberExists.IsSuccessful || !isMemberExists.Data)
        {
            return MemberStatuses.MemberNotFound.GetFailureResult<bool>();
        }

        var enrollmentId = await connection.ExecuteScalarAsync<long>(query, enrollment);

        return Result.Success(true);
    }
    catch (Exception ex)
    {
        return EnrollmentStatuses.FailToEnrollMemberToClass.GetFailureResult<bool>(ex.Message);
    }
    finally
    {
        if (connection.State == ConnectionState.Open)
        {
            connection.Close();
            connection.Dispose();
        }
    }
}

// GOOD EXAMPLE

// Class with delegate functionality
public class DbProvider : IDbProvider
{
    private readonly string _connectionString;
    public DbProvider(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IDbConnection> CreateAndOpenConnection(CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync(ct);
        return connection;
    }
}

// Client code
public async Task<Result<bool>> EnrollMemberToClass(Enrollment enrollment, CancellationToken ct)
{
    var query = @"INSERT INTO Enrollment (class_id, member_id, enrollment_date) 
                  VALUES (@ClassId, @MemberId, @EnrollmentDate);
                  SELECT SCOPE_IDENTITY();";

    try
    {
        using var connection = await DbProvider.CreateConnection(ct);
        
        var isMemberExists = await _memberRepository.IsExists(enrollment.MemberId, ct);
        if (!isMemberExists.IsSuccessful || !isMemberExists.Data)
        {
            return MemberStatuses.MemberNotFound.GetFailureResult<bool>();
        }

        var enrollmentId = await connection.ExecuteScalarAsync<long>(query, enrollment);

        return Result.Success(true);
    }
    catch (Exception ex)
    {
        return EnrollmentStatuses.FailToEnrollMemberToClass.GetFailureResult<bool>(ex.Message);
    }
}

// Introduce Local Extension

// BAD EXAMPLE
public class BaseMessage
{
    public ChatId? ChatId { get; set; }
    public string? Text { get; set; }
    public HardFile? File { get; set; }

    public BaseMessage(long? chatId)
    {
        ChatId = chatId.HasValue ? new ChatId(chatId.Value) : null;
    }

    public BaseMessage(ChatId chatId)
    {
        ChatId = chatId;
    }

    public BaseMessage() { }

    public BaseMessage(long? chatId, string text) : this(chatId)
    {
        Text = text;
    }

    public BaseMessage(long? chatId, string text, HardFile file) : this(chatId, text)
    {
        File = file;
    }
}


// GOOD EXAMPLE

public class BaseMessage
{
    public ChatId? ChatId { get; set; }

    public BaseMessage(long? chatId)
    {
        ChatId = chatId.HasValue ? new ChatId(chatId.Value) : null;
    }
    public BaseMessage(ChatId chatId)
    {
        ChatId = chatId;
    }

    public BaseMessage() { }
}

public class TextMessage : BaseMessage
{
    public TextMessage(long? chatId) : base(chatId) { }
    public TextMessage() { }

    public string Text { get; set; }
}

public class DocumentMessage : TextMessage
{
    public DocumentMessage(long? chatId) 
    : base(chatId) { }

    public HardFile File { get; set; }
}

