public class Monster {
    String name;
    String element;
    byte level;
    String type;
    String description;
    int attack;
    int defense;

    public static void Main (String [] args) {

        Monster darkMagician = new Monster();

        // Atributos do Objeto criado acima
        darkMagician.name = "Mago Negro";
        darkMagician.element = "Dark";
        darkMagician.level = 8;
        darkMagician.type = "Spellcaster";
        darkMagician.description = "O feiticeiro absoluto em termos de ataque e defesa.";
        darkMagician.attack = 2500;
        darkMagician.defense = 2100;

        Console.WriteLine(
            "Monstro: " + darkMagician.name + 
            "\nTipo: " + darkMagician.type + " | Elemento: " + darkMagician.element + 
            "\nLevel: " + darkMagician.level + 
            "\nAtaque: " + darkMagician.attack + " | Defesa: " + darkMagician.defense +
            "\nDescrição \n" + darkMagician.description
        );
    }
}