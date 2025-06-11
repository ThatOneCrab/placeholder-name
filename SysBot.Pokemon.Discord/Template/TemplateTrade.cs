using Discord;
using Discord.Commands;
using PKHeX.Core;

namespace SysBot.Pokemon.Discord;

public class TemplateTrade<T>(PKM pkm, SocketCommandContext Context, PokeTradeHub<T> Hub, PokeTradeDetail<T> Detail) where T : PKM, new()
{
    private readonly PKM pkm = pkm;
    private readonly PKMString<T> pkmString = new(pkm, Hub);
    private readonly SocketCommandContext Context = Context;
    private readonly PokeTradeHub<T> Hub = Hub;
    private readonly PokeTradeDetail<T> Detail = Detail;

    private Color SetColor()
    {
        return Detail.Type switch
        {

            PokeTradeType.Clone => Color.Purple,
            PokeTradeType.Specific => pkm.IsShiny && pkm.ShinyXor == 0 ? Color.Gold : pkm.IsShiny ? Color.LighterGrey : Color.Teal,
            _ => Color.Purple
        };
    }

    public static string GetServerNickname(IGuildUser user)
    {
        try
        {
            return user.DisplayName;
        }
        catch
        {
            return user.GlobalName;
        }
    }

    private EmbedAuthorBuilder SetAuthor()
    {
        var user = Context.User;
        string? trainerName;
        try
        {
            // Ensure 'user' is not null before casting to IGuildUser
            if (user is IGuildUser guildUser)
            {
                trainerName = GetServerNickname(guildUser);
            }
            else
            {
                trainerName = user.Username;
            }
        }
        catch
        {
            trainerName = user.Username;
        }
        EmbedAuthorBuilder author = new()
        {
            Name = $"{trainerName}'s Pokémon",
            IconUrl = pkmString.ballImg
        };
        return author;
    }

    private string SetImageUrl()
    {
        return pkmString.pokeImg;
    }

    private EmbedFooterBuilder SetFooter(int positionNum, string etaMessage = "")
    {
        // Current queue position
        string Position = $"Current Position: {positionNum}";
        // Trainer info
        string Trainer = $"Thank you!";

        // display combined footer content
        string FooterContent = "";
        FooterContent += $"\n{Position}";
        FooterContent += $"\n{Trainer}";
        FooterContent += $"\n{etaMessage}";

        return new EmbedFooterBuilder { Text = FooterContent };
    }

    private void SetFiled1(EmbedBuilder embed)
    {
        // Obtain species's info
        string speciesInfo = pkmString.Species;
        // Obtain holditem's info
        string shiny = pkmString.Shiny;
        // Obtain Gender's info (Display Emoji if used, otherwise Gender)
        // LINQ C#: format is condition ? code when condition met : code when condition not met
        // LINQ C#: if GenderEmoji's option is enabled in the settings use GenderEmoji, otherwise use text Gender
        string gender = Hub.Config.Discord.EmbedSetting.GenderEmoji ? pkmString.GenderEmoji : pkmString.Gender;
        // Obtain Mark's info
        (_, string markEntryText) = pkmString.Mark;
        // Build info
        string filedName = $"{shiny} {speciesInfo} {gender} {markEntryText}";
        string filedValue = $"** **";

        embed.AddField(filedName, filedValue, false);
    }

    private void SetFiled2(EmbedBuilder embed)
    {

        string heldItem = pkmString.holdItem;
        if (string.IsNullOrEmpty(heldItem))
            return;

        string fieldName = $"**Item Held**: {heldItem}";
        string fieldValue = "** **";


        string itemImageUrl = GetSerebiiImageUrl(heldItem);

        embed.AddField(fieldName, fieldValue, false);

        if (!string.IsNullOrEmpty(itemImageUrl))
        {
            embed.WithThumbnailUrl(itemImageUrl);
        }
    }

    private string GetSerebiiImageUrl(string heldItem)
    {

        string formattedItemName = heldItem.ToLower().Replace(" ", "");
        return $"https://www.serebii.net/itemdex/sprites/{formattedItemName}.png";
    }

    private void SetFiled3_1(EmbedBuilder embed)
    {
        // Obtain teraType's info
        string teraType = pkmString.TeraType;
        // Define Level's info
        int level = pkm.CurrentLevel;
        // Define Ability's info
        string ability = pkmString.Ability;
        // Obtain Nature's Nature
        string nature = pkmString.Nature;
        // Obtain Scale's info
        string scale = pkmString.Scale;
        // Obtain Mark's info
        (string mark, _) = pkmString.Mark;

        // Build info 
        var trademessage = "";
        // trademessage += pkm.Generation != 9 ? "" : useEmoji ? $"**Emoji:** {Emoji}\n" : $"**TeraType:** {teraType}\n";
        // LINQ C#: format is condition ? code when condition met : code when condition not met
        // LINQ C#: If pkm.generation is 9, check secondCondition, if secondCondition is true, result will be valueIfTrue otherwise
        // valueIfFalse if secondcondition is false, result will be empty string if pkm.generation is not 9
        // LINQ C#: if TeraTypeEmoji's option is enabled in the settings, use TeraTypeEmoji, otherwise use text 

        trademessage += $"**Level:** {level}\n";
        trademessage += $"**Tera Type:** {teraType}\n";
        trademessage += $"**Ability:** {ability}\n";
        trademessage += $"**Nature:** {nature}\n";
        trademessage += $"**Scale:** {scale}\n";
        trademessage += mark != "" ? $"**Pokemon Mark:** {mark}\n" : "";
        trademessage += $"**IVs:** {string.Join("/", pkmString.IVs)}";

        if (pkm.EV_HP > 0 || pkm.EV_ATK > 0 || pkm.EV_DEF > 0 || pkm.EV_SPA > 0 || pkm.EV_SPD > 0 || pkm.EV_SPE > 0)
        {
            trademessage += $"\n**EVs:** {pkm.EV_HP} HP / {pkm.EV_ATK} Atk / {pkm.EV_DEF} Def / {pkm.EV_SPA} SpA / {pkm.EV_SPD} SpD / {pkm.EV_SPE} Spe";
        }

        // Build info
        string filedName = $"__Pokémon Stats:__";
        string filedValue = $"{trademessage}";

        embed.AddField(filedName, filedValue, true);
    }

    private void SetFiled3_2(EmbedBuilder embed)
    {
        string moveset = "";
        for (int i = 0; i < pkmString.Moves.Count; i++)
        {
            // Obtain Moveset
            string moveString = pkmString.Moves[i];
            if (moveString == "(None)")
                continue;
            // Obtain MovePP
            int movePP = i == 0 ? pkm.Move1_PP : i == 1 ? pkm.Move2_PP : i == 2 ? pkm.Move3_PP : pkm.Move4_PP;
            // Setup moveEmoji
            string moveEmoji = Hub.Config.Discord.EmbedSetting.UseMoveEmoji ? pkmString.MovesEmoji[i] : "";
            // Generate Moveset's info
            moveset += $" {moveEmoji}{moveString} \n";
        }

        string FiledName = $"Moveset:";
        string FiledValue = moveset;

        embed.AddField(FiledName, FiledValue, true);
    }

    private static void SetFiledTemp(EmbedBuilder embed)
    {
        embed.AddField($"** **", $"** **", true);
    }

    public EmbedBuilder Generate(int positionNum, string etaMessage = "")
    {
        var nonTrade = Detail.Type is PokeTradeType.Clone or PokeTradeType.Dump or PokeTradeType.Seed;
        var image = Detail.Type switch
        {
            PokeTradeType.Clone => "https://raw.githubusercontent.com/plusReedy/Images-Sprites-Balls/refs/heads/main/clone.png",
            PokeTradeType.Dump => "https://raw.githubusercontent.com/plusReedy/Images-Sprites-Balls/refs/heads/main/dump.png",
            PokeTradeType.Seed => "https://raw.githubusercontent.com/plusReedy/Images-Sprites-Balls/refs/heads/main/seed.png",
            _ => SetImageUrl()
        };
        // Build discord Embed
        var embed = new EmbedBuilder
        {
            Color = SetColor(),
            Author = nonTrade ? null : SetAuthor(),
            Description = nonTrade ? $"<@{Detail.Trainer.ID}> - Added to the {Detail.Type} Queue" : null,
            Footer = SetFooter(positionNum),
            ImageUrl = image,

        };
        if (!nonTrade)
        {
            // Build embed files        
            SetFiled1(embed);
            SetFiled2(embed);
            SetFiled3_1(embed);
            SetFiledTemp(embed);
            SetFiled3_2(embed);
            SetFiledTemp(embed);
        }

        return embed;
    }
}
