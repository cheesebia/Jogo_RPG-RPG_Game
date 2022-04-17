namespace jogo_rpg_rpg_game.src.Entities
{
    public class Monster
    {
        public Monster(string name, int healthPointMonster, bool monsterAlive){
            this.monsterName = name;
            this.healthPointMonster = healthPointMonster;
            this.monsterAlive = true;
        }
        public string monsterName;
        public int healthPointMonster;
        public bool monsterAlive;
        
        Random diceNumber = new Random();
        public int MonsterDice(){
            return diceNumber.Next(1,21);
        }

        Random targetMonster = new Random();
        public int Target(){
            return targetMonster.Next(2);
        }
    }
}