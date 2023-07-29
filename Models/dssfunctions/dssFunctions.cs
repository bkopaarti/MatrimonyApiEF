namespace MatrimonyApiEF.Models.dssfunctions
{
    public class ResultFormat
    {
        public byte status_cd { get; set; } = 1;

        public object? data { get; set; }

        public errors errors { get; set; } = new errors();
    }

    public class errors
    {
        public string? error_cd { get; set; }

        public string? message { get; set; }

        public object? exception { get; set; }
    }

    public class UserSettings
    {        public uploadfile uploadfile { get; set; } = new uploadfile();
        public string? dbPath { get; set; }
    }

        public class uploadfile
    {
        public string path { get; set; } = null!;


    }
}
