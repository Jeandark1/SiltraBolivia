


namespace CargoApi.Application.Common
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public string Action { get; set; }

        public ApiResponse(bool success, string message, T data = default, string action = null)
        {
            Success = success;
            Message = message;
            Data = data;
            Action = action;
        }
        // Factory method for success response
        public static ApiResponse<T> SuccessResponse(
            string message, 
            T data = default, 
            string action = "success")
        {
            return new ApiResponse<T>(true, message, data, action);
        }
        // Factory method for error response
        public static ApiResponse<T> ErrorResponse
            (string message, 
            List<string> errors = null, 
            string action = "error")
        {
            var response = new ApiResponse<T>(false, message, default, action);
            if (errors != null) response.Errors = errors;
            return response;
        }

        // Full constructor
        public static ApiResponse<T> ValidationErrorResponse(
            List<string> errors, 
            string message = "Validation errors occurred")
        {
            return new ApiResponse<T>(false, message, default, "validation_error")
            {
                Errors = errors
            };
        }
       
    }

    // Para respuestas sin datos
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public string Action { get; set; }

        public ApiResponse(bool success, string message, string action = null)
        {
            Success = success;
            Message = message;
            Action = action;
        }

        public static ApiResponse SuccessResponse(
            string message, string action = "success")
        {
            return new ApiResponse(true, message, action);
        }

        public static ApiResponse ErrorResponse(
            string message, List<string> errors = null, string action = "error")
        {
            var response = new ApiResponse(false, message, action);
            if (errors != null) response.Errors = errors;
            return response;
        }

        public static object? ValidationErrorResponse(List<string> errorMessages, string v)
        {
            throw new NotImplementedException();
        }
    }
}
