﻿using CentralDeErro.Core.Enums;
using Flunt.Notifications;
using Flunt.Validations;

namespace CentralDeErro.Core.Entities.DTOs
{
    public class SourceCreateDTO : Notifiable, IValidatable
    {
        public int Id { get; }
        public string Address { get; set; }
        public Environment Environment { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMaxLen(Address,1024,"Address", "This field should have no more than 1024 chars.")
                .HasMinLen(Address, 6, "Address", "This field should have at least 6 chars.")
                .IsBetween(Environment.GetHashCode(), 0, (Environment.GetNames(typeof(Environment)).Length - 1), "Environment", "The value must be between 0 and 2")
                );
        }
    }
}
