﻿public class BotConfig
{
    public string DiscordToken { get; set; } = "";
    public string WebHookUrl { get; set; } = "";
    public string TwitterClientKey { get; set; } = "";
    public string TwitterClientSecret { get; set; } = "";
    public string TwitterClientBearerToken { get; set; } = "";
    public ulong TestSlashCommandGuildId { get; set; } = 0;
    public string RedisOption { get; set; } = "localhost:6379,syncTimeout=3000";

    public void InitBotConfig()
    {
        try { File.WriteAllText("bot_config_example.json", JsonConvert.SerializeObject(new BotConfig(), Formatting.Indented)); } catch { }
        if (!File.Exists("bot_config.json"))
        {
            Log.Error($"bot_config.json遺失，請依照 {Path.GetFullPath("bot_config_example.json")} 內的格式填入正確的數值");
            if (!Console.IsInputRedirected)
                Console.ReadKey();
            Environment.Exit(3);
        }

        var config = JsonConvert.DeserializeObject<BotConfig>(File.ReadAllText("bot_config.json"));

        try
        {
            if (string.IsNullOrWhiteSpace(config.DiscordToken))
            {
                Log.Error("DiscordToken遺失，請輸入至bot_config.json後重開Bot");
                if (!Console.IsInputRedirected)
                    Console.ReadKey();
                Environment.Exit(3);
            }

            if (string.IsNullOrWhiteSpace(config.WebHookUrl))
            {
                Log.Error("WebHookUrl遺失，請輸入至bot_config.json後重開Bot");
                if (!Console.IsInputRedirected)
                    Console.ReadKey();
                Environment.Exit(3);
            }

            if (string.IsNullOrWhiteSpace(config.TwitterClientKey))
            {
                Log.Error("TwitterClientKey遺失，請輸入至bot_config.json後重開Bot");
                if (!Console.IsInputRedirected)
                    Console.ReadKey();
                Environment.Exit(3);
            }

            if (string.IsNullOrWhiteSpace(config.TwitterClientSecret))
            {
                Log.Error("TwitterClientSecret遺失，請輸入至bot_config.json後重開Bot");
                if (!Console.IsInputRedirected)
                    Console.ReadKey();
                Environment.Exit(3);
            }

            //if (string.IsNullOrWhiteSpace(config.GoogleClientId))
            //{
            //    Log.Error("GoogleClientId遺失，請輸入至credentials.json後重開Bot");
            //    if (!Console.IsInputRedirected)
            //        Console.ReadKey();
            //    Environment.Exit(3);
            //}

            //if (string.IsNullOrWhiteSpace(config.GoogleClientSecret))
            //{
            //    Log.Error("GoogleClientSecret遺失，請輸入至credentials.json後重開Bot");
            //    if (!Console.IsInputRedirected)
            //        Console.ReadKey();
            //    Environment.Exit(3);
            //}

            DiscordToken = config.DiscordToken;
            WebHookUrl = config.WebHookUrl;
            TwitterClientKey = config.TwitterClientKey;
            TwitterClientSecret = config.TwitterClientSecret;
            TwitterClientBearerToken = config.TwitterClientBearerToken;
            TestSlashCommandGuildId = config.TestSlashCommandGuildId;
            RedisOption = config.RedisOption;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            throw;
        }
    }
}