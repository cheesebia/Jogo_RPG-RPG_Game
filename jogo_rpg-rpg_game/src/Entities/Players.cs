#nullable disable
namespace jogo_rpg_rpg_game.src.Entities
{
    public class Players
    {
        public Players(string name, int healthPoint, bool alive){
            this.name = name;
            this.healthPoint = 10;
            this.alive = true;
        }
        public string name;
        public int healthPoint;
        public bool alive;
        Random diceNumber = new Random();
        public int Dice(){ //Classe só pro dado? e pra aleatoriedade.
            return diceNumber.Next(1,21);
        }
        static string playDice(string name){
            Console.WriteLine("Pressione 1 para jogar os dados.");
            string userPlayDice = Console.ReadLine();
            return userPlayDice;
        }
    }
}