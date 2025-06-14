using Discord;
using Discord.Commands;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace SysBot.Pokemon.Discord;

// src: https://github.com/foxbot/patek/blob/master/src/Patek/Modules/InfoModule.cs
// ISC License (ISC)
// Copyright 2017, Christopher F. <foxbot@protonmail.com>
public class InfoModule : ModuleBase<SocketCommandContext>
{
    private const string detail = "I am an open-source Discord bot powered by PKHeX.Core and other open-source software.";
    private const string repo = "https://github.com/Manu098vm/SysBot.NET";
    private const string upstream = "https://github.com/kwsch/SysBot.NET";
    private const string repo2 = "https://github.com/ThatOneCrab/placeholder-name";
    private const string buildversion = "1.0.0";

    [Command("info")]
    [Alias("about", "whoami", "owner")]
    public async Task InfoAsync()
    {
        var app = await Context.Client.GetApplicationInfoAsync().ConfigureAwait(false);

        var builder = new EmbedBuilder
        {
            Title = "Here's a bit about me!",
            Color = new Color(114, 137, 218),
            ThumbnailUrl = "https://media.discordapp.net/attachments/1234791557396172874/1383064282748682313/72x72_pokeball.png?ex=684d6e7d&is=684c1cfd&hm=20b42111f140319c8ab3933670156cecba8a1f4a1c5e39159c1671b00d8f228f&=&format=webp&quality=lossless.png",
            Description = detail,
        };

        builder.AddField("Info",
            $"- [This fork Source Code]({repo2}) by Crab and Reedy built off of [This fork Source Code]({repo}) by manu098vm\n" +
            $"Thanks to notzyro, santacrab2, berichan and 9Bitdo for portions of code, help and updating.\n" +
            $"- [Upstream Source Code]({upstream}) by kwsch\n" +
            $"Thanks to Kurt, Anubis and Architdate for writing the original SysBot code.\n" +
            $"- {Format.Bold("Owner")}: {app.Owner} ({app.Owner.Id})\n" +
            $"- {Format.Bold("Library")}: Discord.Net ({DiscordConfig.Version})\n" +
            $"- {Format.Bold("Uptime")}: {GetUptime()}\n" +
            $"- {Format.Bold("Runtime")}: {RuntimeInformation.FrameworkDescription} {RuntimeInformation.ProcessArchitecture} " +
            $"({RuntimeInformation.OSDescription} {RuntimeInformation.OSArchitecture})\n" +
            $"- {Format.Bold("Buildtime")}: {GetVersionInfo("SysBot.Base", false)}\n" +
            $"- {Format.Bold("Build Version")}: {buildversion}\n" +
            $"- {Format.Bold("Core Version")}: {GetVersionInfo("PKHeX.Core")}\n" +
            $"- {Format.Bold("AutoLegality Version")}: {GetVersionInfo("PKHeX.Core.AutoMod")}\n"
        );

        builder.AddField("Stats",
            $"- {Format.Bold("Heap Size")}: {GetHeapSize()}MiB\n" +
            $"- {Format.Bold("Guilds")}: {Context.Client.Guilds.Count}\n" +
            $"- {Format.Bold("Channels")}: {Context.Client.Guilds.Sum(g => g.Channels.Count)}\n" +
            $"- {Format.Bold("Users")}: {Context.Client.Guilds.Sum(g => g.MemberCount)}\n"
        );

        await ReplyAsync("", embed: builder.Build()).ConfigureAwait(false);
    }

    private static string GetUptime() => (DateTime.Now - Process.GetCurrentProcess().StartTime).ToString(@"dd\.hh\:mm\:ss");
    private static string GetHeapSize() => Math.Round(GC.GetTotalMemory(true) / (1024.0 * 1024.0), 2).ToString(CultureInfo.CurrentCulture);

    private static string GetVersionInfo(string assemblyName, bool inclVersion = true)
    {
        const string _default = "Unknown";
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        var assembly = Array.Find(assemblies, x => x.GetName().Name == assemblyName);

        var attribute = assembly?.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
        if (attribute is null)
            return _default;

        var info = attribute.InformationalVersion;
        var split = info.Split('+');
        if (split.Length >= 2)
        {
            var version = split[0];
            var revision = split[1];
            if (DateTime.TryParseExact(revision, "yyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var buildTime))
                return (inclVersion ? $"{version} " : "") + $@"{buildTime:yy-MM-dd\.hh\:mm}";
            return inclVersion ? version : _default;
        }
        return _default;
    }
}
