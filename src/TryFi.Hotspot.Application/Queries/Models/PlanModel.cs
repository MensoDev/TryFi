namespace TryFi.Hotspot.Application.Queries.Models
{
    public record PlanModel
    {
        public PlanModel(string name, string upload, string download)
        {
            Name = name;
            Upload = upload;
            Download = download;
        }

        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Upload { get; init; }
        public string Download { get; init; }

    }
}
