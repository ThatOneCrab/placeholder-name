using Discord;
using Discord.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SysBot.Pokemon.Discord;

public class HelpModule(CommandService Service) : ModuleBase<SocketCommandContext>
{
    [Command("help")]
    [Summary("Lists available commands.")]
    public async Task HelpAsync()
    {
        var builder = new EmbedBuilder

        {
            Title = "Help has arrived!",
            Color = new Color(114, 137, 218),
            ThumbnailUrl = "https://media.discordapp.net/attachments/1234791557396172874/1383064282748682313/72x72_pokeball.png?ex=684d6e7d&is=684c1cfd&hm=20b42111f140319c8ab3933670156cecba8a1f4a1c5e39159c1671b00d8f228f&=&format=webp&quality=lossless.png",
            Description = "These are the commands you can use:",
        };

        var mgr = SysCordSettings.Manager;
        var app = await Context.Client.GetApplicationInfoAsync().ConfigureAwait(false);
        var owner = app.Owner.Id;
        var uid = Context.User.Id;

        foreach (var module in Service.Modules)
        {
            string? description = null;
            HashSet<string> mentioned = [];
            foreach (var cmd in module.Commands)
            {
                var name = cmd.Name;
                if (mentioned.Contains(name))
                    continue;
                if (cmd.Attributes.Any(z => z is RequireOwnerAttribute) && owner != uid)
                    continue;
                if (cmd.Attributes.Any(z => z is RequireSudoAttribute) && !mgr.CanUseSudo(uid))
                    continue;

                mentioned.Add(name);
                var result = await cmd.CheckPreconditionsAsync(Context).ConfigureAwait(false);
                if (result.IsSuccess)
                    description += $"{cmd.Aliases[0]}\n";
            }
            if (string.IsNullOrWhiteSpace(description))
                continue;

            var moduleName = module.Name;
            var gen = moduleName.IndexOf('`');
            if (gen != -1)
                moduleName = moduleName[..gen];

            builder.AddField(x =>
            {
                x.Name = moduleName;
                x.Value = description;
                x.IsInline = false;
            });
        }

        await ReplyAsync("", false, builder.Build()).ConfigureAwait(false);
    }

    [Command("help")]
    [Summary("Lists information about a specific command.")]
    public async Task HelpAsync([Summary("The command you want help for")] string command)
    {
        var result = Service.Search(Context, command);

        if (!result.IsSuccess)
        {
            await ReplyAsync($"Sorry, I couldn't find a command like **{command}**.").ConfigureAwait(false);
            return;
        }

        var builder = new EmbedBuilder
        {
            Color = new Color(114, 137, 218),
            Description = $"Here are some commands like **{command}**:",
        };

        foreach (var match in result.Commands)
        {
            var cmd = match.Command;

            builder.AddField(x =>
            {
                x.Name = string.Join(", ", cmd.Aliases);
                x.Value = GetCommandSummary(cmd);
                x.IsInline = false;
            });
        }

        await ReplyAsync("Help has arrived!", false, builder.Build()).ConfigureAwait(false);
    }

    private static string GetCommandSummary(CommandInfo cmd)
    {
        return $"Summary: {cmd.Summary}\nParameters: {GetParameterSummary(cmd.Parameters)}";
    }

    private static string GetParameterSummary(IReadOnlyList<ParameterInfo> p)
    {
        if (p.Count == 0)
            return "None";
        return $"{p.Count}\n- " + string.Join("\n- ", p.Select(GetParameterSummary));
    }

    private static string GetParameterSummary(ParameterInfo z)
    {
        var result = z.Name;
        if (!string.IsNullOrWhiteSpace(z.Summary))
            result += $" ({z.Summary})";
        return result;
    }
}
