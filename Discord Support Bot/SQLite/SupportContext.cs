﻿using Microsoft.EntityFrameworkCore;

namespace Discord_Support_Bot.SQLite
{
    class SupportContext : DbContext
    {
        public DbSet<TrustedGuild> TrustedGuild { get; set; }
        public DbSet<UpdateGuildInfo> UpdateGuildInfo { get; set; }
        public DbSet<NCchannelCOD> NCchannelCOD { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={Program.GetDataFilePath("DataBase.db")}");
    }
}
