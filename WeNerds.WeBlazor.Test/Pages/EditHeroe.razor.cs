using Microsoft.AspNetCore.WebUtilities;
using WeNerds.WeBlazor.Test.Models;

namespace WeNerds.WeBlazor.Test.Pages;

public partial class EditHeroe
{
    private DataTest _item;
    private ICollection<DataTest> Items { get; set; }
    private int _id;
    public EditHeroe()
    {
        Items = new List<DataTest>
        {
            new DataTest
            {
                Id = 1,
                Name = "Superman",
                Description = "O Último Filho de Krypton, com poderes sobre-humanos.",
                Subdomain = "superman",
                Email = "superman@gmail.com",
                Status = true
            },
            new DataTest
            {
                Id = 2,
                Name = "Batman",
                Description = "O Cavaleiro das Trevas, um detetive e combatente do crime.",
                Subdomain = "batman",
                Email = "batman@gmail.com",
                Status = true
            },
            new DataTest
            {
                Id = 3,
                Name = "Wonder Woman",
                Description = "A Princesa Amazona com força e habilidades divinas.",
                Subdomain = "wonderwoman",
                Email = "wonderwoman@gmail.com",
                Status = true
            },
            new DataTest
            {
                Id = 4,
                Name = "The Flash",
                Description = "O Velocista Escarlate com supervelocidade.",
                Subdomain = "theflash",
                Email = "theflash@gmail.com",
                Status = false
            },
            new DataTest
            {
                Id = 5,
                Name = "Green Lantern",
                Description = "Protetor do setor espacial com um anel de poder.",
                Subdomain = "greenlantern",
                Email = "greenlantern@gmail.com",
                Status = true
            },
            new DataTest
            {
                Id = 6,
                Name = "Aquaman",
                Description = "Rei de Atlântida com poderes aquáticos e controle sobre os mares.",
                Subdomain = "aquaman",
                Email = "aquaman@gmail.com",
                Status = false
            },
            new DataTest
            {
                Id = 7,
                Name = "Cyborg",
                Description = "Metahumano com partes cibernéticas avançadas.",
                Subdomain = "cyborg",
                Email = "cyborg@gmail.com",
                Status = true
            },
            new DataTest
            {
                Id = 8,
                Name = "Green Arrow",
                Description = "Arqueiro habilidoso e defensor da justiça.",
                Subdomain = "greenarrow",
                Email = "greenarrow@gmail.com",
                Status = true
            },
            new DataTest
            {
                Id = 9,
                Name = "Martian Manhunter",
                Description = "Último Marciano com habilidades telepáticas e metamorfas.",
                Subdomain = "martianmanhunter",
                Email = "martianmanhunter@gmail.com",
                Status = true
            },
            new DataTest
            {
                Id = 10,
                Name = "Supergirl",
                Description = "Prima do Superman com poderes similares.",
                Subdomain = "supergirl",
                Email = "supergirl@gmail.com",
                Status = true
            },
            new DataTest
            {
                Id = 11,
                Name = "Black Canary",
                Description = "Expert em artes marciais e possui um grito supersônico.",
                Subdomain = "blackcanary",
                Email = "blackcanary@gmail.com",
                Status = true
            },
            new DataTest
            {
                Id = 12,
                Name = "Hawkman",
                Description = "Guerreiro alado com conexões a vidas passadas.",
                Subdomain = "hawkman",
                Email = "hawkman@gmail.com",
                Status = true
            },
            new DataTest
            {
                Id = 13,
                Name = "Zatanna",
                Description = "Mágica e ilusionista poderosa.",
                Subdomain = "zatanna",
                Email = "zatanna@gmail.com",
                Status = true
            },
            new DataTest
            {
                Id = 14,
                Name = "Shazam",
                Description = "Jovem herói com o poder de seis deuses mitológicos.",
                Subdomain = "shazam",
                Email = "shazam@gmail.com",
                Status = true
            },
            new DataTest
            {
                Id = 15,
                Name = "Nightwing",
                Description = "Ex-parceiro do Batman e líder da equipe Jovens Titãs.",
                Subdomain = "nightwing",
                Email = "nightwing@gmail.com",
                Status = true
            },
            new DataTest
            {
                Id = 16,
                Name = "Raven",
                Description = "Empata com poderes sombrios e misteriosos.",
                Subdomain = "raven",
                Email = "raven@gmail.com",
                Status = true
            },
            new DataTest
            {
                Id = 17,
                Name = "Red Tornado",
                Description = "Android com controle sobre o vento e o clima.",
                Subdomain = "redtornado",
                Email = "redtornado@gmail.com",
                Status = true
            },
            new DataTest
            {
                Id = 18,
                Name = "Batgirl",
                Description = "Habilidosa detetive e combatente do crime.",
                Subdomain = "batgirl",
                Email = "batgirl@gmail.com",
                Status = true
            },
            new DataTest
            {
                Id = 19,
                Name = "Beast Boy",
                Description = "Metamorfo que pode se transformar em animais.",
                Subdomain = "beastboy",
                Email = "beastboy@gmail.com",
                Status = true
            },
            new DataTest
            {
                Id = 20,
                Name = "Static",
                Description = "Jovem herói com controle sobre eletricidade.",
                Subdomain = "static",
                Email = "static@gmail.com",
                Status = true
            }
        };
    }
    protected override void OnInitialized()
    {

        var uri = _navigation.ToAbsoluteUri(_navigation.Uri);
        var queryStrings = QueryHelpers.ParseQuery(uri.Query);

        _id = 0;
        if (queryStrings.TryGetValue("id", out var id))
        {
           // _id = (int)id.ToString();
          //  int.TryParse($"{id}", out _id);
        }


        _item = Items.FirstOrDefault(x => x.Id == _id);
        
    }
}
