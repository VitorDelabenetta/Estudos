using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game {

    internal class Entidade {
        private int lifePoints;
        private int currentLife;
        private int attackPoints;
        private int healingPoints;
        private string entityName;
        private string vocation;
        private Random randomly;

        public int Vida {
            get {return currentLife;}
        }
        public int Poder {
            get {return attackPoints;}
        }
        public string Nome {
            get {return entityName;}
        }
         public string Classe {
            get {return vocation;}
        }
        public bool Falecimento {
            get {return currentLife <= 0;}
        }

        public Entidade (int lifePoints, int attackPoints, int healingPoints, string entityName, string vocation) {

            this.lifePoints = lifePoints;
            this.currentLife = lifePoints;
            this.attackPoints = attackPoints;
            this.healingPoints = healingPoints;
            this.entityName = entityName;
            this.vocation = vocation;
            this.randomly = new Random();

        }

        public void Ataque (Entidade proferirAtaque) {
            double random = randomly.NextDouble();

            if (vocation == "wizard") {
                random = random / 2 + 0.75f; 
            } else {
                random = random / 2 + 0.5f; 
            }
            // Produz ataque até 100% do attackPoints - caso seja Wizard o ataque pode ser maior

            int randomDamage = (int)(attackPoints * random);
            proferirAtaque.Dano(randomDamage);

            if (entityName != "Eldrich Horror") {
                Console.WriteLine("Você atacou o terrível " + proferirAtaque.entityName + ". Ele tomou " + randomDamage + " de dano.\n");
            }
        }

        public void Dano (int damage) {
            currentLife = currentLife - damage;

            if(Falecimento) {
                Console.Write("\n" + entityName + " despedira-se deste mundo em último suspiro tortuoso.");
            }
        }

        public void Cura() {
            double random = randomly.NextDouble();

            if (vocation == "druid") {
                random = random / 2 + 0.75f; 
            } else {
                random = random / 2 + 0.5f; 
            }
            // Produz cura até 100% do healingPoints - se for Druid pode curar mais

            int randomHealing = (int)(random * healingPoints);
            currentLife = randomHealing + currentLife > lifePoints ? lifePoints : currentLife + randomHealing;
            // Se a vida atual for igual ao total, retorna o total. Se não, retorna a vida atual mais a cura

            Console.WriteLine("Sua magia emana como uma brisa gélida na noite.\n[Vitalidade aumentou " + randomHealing + " pontos]\n");
        }

        public void Desistir() {
            currentLife = 0;
            Console.Write("\n");
        }
    }
}