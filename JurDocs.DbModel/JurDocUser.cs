﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JurDocs.DbModel
{
    /// <summary>
    /// 
    /// </summary>
    public class JurDocUser
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Path { get; set; }

        class Configuration : IEntityTypeConfiguration<JurDocUser>
        {
            public void Configure(EntityTypeBuilder<JurDocUser> builder)
            {
            }
        }
    }
}
