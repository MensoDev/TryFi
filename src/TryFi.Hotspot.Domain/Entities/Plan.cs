﻿using TryFi.Kernel.Domain.DomainObjects;

namespace TryFi.Hotspot.Domain.Entities
{
    public class Plan : Entity
    {

        public Plan(string name, string upload, string download)
        {
            this.Name = name;
            this.Upload = upload;
            this.Download = download;

            Validate();
        }

        // EF Compatibility
        protected Plan()
        {}

        public string Name { get; private set; }
        public string Upload { get; private set; }
        public string Download { get; private set; }
        public string RegistrationDate { get; private set; }


        public override void Validate()
        {
            AssertionConcern.NotEmpty(Name, "The Name is required");
            AssertionConcern.MinLength(Name, 3, "The name must be at least three characters");

            AssertionConcern.NotEmpty(Upload, "The Upload is required");
            AssertionConcern.NotEmpty(Download, "The Download is required");
        }
    }
}
