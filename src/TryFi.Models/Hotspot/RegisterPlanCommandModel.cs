using System.ComponentModel.DataAnnotations;

namespace TryFi.Models.Hotspot
{
    public class RegisterPlanCommandModel
    {
        public RegisterPlanCommandModel(string name, string upload, string download)
        {
            Name = name;
            Upload = upload;
            Download = download;
        }

        public RegisterPlanCommandModel()
        {

        }

        [Required]
        [MinLength(4)]
        public string Name { get;  set; }
        
        [Required]
        [MinLength(2)]
        public string Upload { get;  set; }

        [Required]
        [MinLength(3)]
        public string Download { get;  set; }
    }
}
