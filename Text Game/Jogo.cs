using System.Security.Cryptography.X509Certificates;
using Game;

// Lore

Console.WriteLine(
    "[Levante-se aventureiro, o mal cinge seu caminho]\n" + "Você acorda em uma estranhamente silenciosa floresta ao cair da noite negra. A escuridão consome aquelas paragens do Bosquescuro, embora ainda seja possível observar pelas folhagens dos altos pinheiros a face prateada do Luar, entreolhando pelas nuvens cinzentas.\n");
Console.WriteLine("A sensação é de que o murmurejo do vento entre os pinheiros entoavam vosso nome.");
Console.WriteLine("[Diga-me, qual seu nome?]");
string nome = Console.ReadLine();

Console.WriteLine("\nOs ventos sibilavam macabramente por '" + nome + "' e isso lhe despertava uma ansiedade premonitiva; algo não estava certo neste cenário. Você tateia ao redor procurando consolo e proteção na luz que emanou ao acender sua lamparina. Entretando, conseguir enxergar em meio a este cenário desolador não parecera alívio maior do que sua prévia situação.");

string vocacao;
do {
    Console.WriteLine("[Antes de iniciarmos, escolha sua vocação: 'Druid' ou 'Wizard']");
    string selecaoVocacional = Console.ReadLine();
    vocacao = selecaoVocacional.ToLower();

} while (vocacao != "druid" && vocacao != "wizard");

Console.WriteLine("\nLenta e assustadoramente uma horrenda sombra ergueu-se a três passos de vossa fronte. Reconheceras imediatamente a entidade como “O Eldritch”, um resquício de malignidade dos tempos imemoriais que assombrava aquelas paragens e consumia a alma dos vagantes menos preparados");


// Início do Jogo

Entidade jogador = new Entidade(100, 10, 10, nome, vocacao);
Entidade oponente = new Entidade(120, 10, 8, "Eldrich Horror", null);
Random randomly = new Random();

Console.WriteLine("\n" + nome + ", mesmo tendo sido pego de surpresa, a adrenalina o assoma e realizas seu primeiro movimento.");

do {
    // Console.WriteLine("\n" + jogador.Nome + " HP: " + jogador.Vida + " ATK: " + jogador.Poder);
    Console.WriteLine("[O que desejas fazer: 'Atacar' ou 'Curar'?]");
    string escolha = Console.ReadLine();
    string movimento = escolha.ToUpper();

    if (movimento == "ATACAR") {
        jogador.Ataque(oponente);
    } 
    else if (movimento == "CURAR") {
        jogador.Cura();
    }
    else if (movimento == "DESISTIR" || movimento == "DESISTO") {
        jogador.Desistir();
    }
    else {
        Console.WriteLine("No antro da batalha, seus sentidos ficaram demasiados confusos para uma decisão e seu turno foi perdido.\n");
    }

    Console.WriteLine(jogador.Nome + " [" + jogador.Classe + "] HP: " + jogador.Vida + " | ATK: " + jogador.Poder + "\n" + oponente.Nome + " [???] HP: " + oponente.Vida + " | ATK: " + oponente.Poder);

    int random = randomly.Next(0, 1);
    if (random == 0) {
        oponente.Ataque(jogador);
    } else {
        oponente.Cura();
    }
} while (!jogador.Falecimento && !oponente.Falecimento);

Console.WriteLine("\n[Um último gemido agonizante ecoou por Bosquescuro e apenas um prostrava-se em pé ao final do combate]");