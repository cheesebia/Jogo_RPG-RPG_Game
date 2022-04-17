#nullable disable
using jogo_rpg_rpg_game.src.Entities;
//Entrada dos jogadores:
Players[] players = new Players[2];
int iPlayers = 0;
Console.WriteLine("Insira o nome do jogador 1:");
Players player1 = new Players(Console.ReadLine(), 10, true);
players[iPlayers] = player1;
iPlayers++;
Console.WriteLine("Insira o nome do jogador 2:");
Players player2 = new Players(Console.ReadLine(), 10, true);
Monster monster = new Monster("Goblin", 30, true);
players[iPlayers] = player2;

Console.WriteLine();
Console.WriteLine($"Na batalha: jogador 1 {player1.name} com {player1.healthPoint} de HP e jogador 2 {player2.name} com {player2.healthPoint} de HP, contra o monstro {monster.monsterName} com {monster.healthPointMonster} de HP.");
Console.WriteLine();

iPlayers = 0;
int first = monster.Target();
if (first == 1){
    iPlayers = first;
} else {
    iPlayers = first;
}

Console.WriteLine(@$"O jogador {players[iPlayers].name} irá começar.
");

while ((player1.alive == true && player2.alive == true) || monster.monsterAlive == true){

    string playDice(){
    Console.WriteLine("    Pressione 1 para jogar os dados de ataque.");
        string userPlayDice = Console.ReadLine();
        return userPlayDice;
    }
    string userPlayDice = playDice(); //serve pra algo??
    switch (userPlayDice){
        case "1":
            break;
        default:
            throw new ArgumentOutOfRangeException();
    }
    int diceValue = players[iPlayers].Dice();
    if (diceValue == 1){
        players[iPlayers].healthPoint = players[iPlayers].healthPoint - 5;
        Console.WriteLine($"O jogador {players[iPlayers].name} cometeu um erro crítico na realização de seu golpe e perdeu 5 HP.");
        if (players[iPlayers].healthPoint != 0){
            Console.WriteLine($"{players[iPlayers].name} está agora com {players[iPlayers].healthPoint} de HP.");
        } else {
            Console.WriteLine($"O jogador {players[iPlayers].name} morreu.");
            players[iPlayers].alive = false;
        }
    } else if (diceValue > 1 && diceValue < 10){
        Console.WriteLine($"O jogador {players[iPlayers].name} errou o golpe.");
    } else if (diceValue >= 10 && diceValue < 20){
        Console.WriteLine($"O jogador {players[iPlayers].name} desferiu um golpe contra o monstro, que tentará se defender.");
        int defenseValue = monster.MonsterDice();
        if (defenseValue > diceValue || defenseValue == diceValue){
            Console.WriteLine($"O monstro {monster.monsterName} se defendeu do golpe.");
        } else {
            monster.healthPointMonster = monster.healthPointMonster - 5;
            Console.WriteLine(@$"O monstro {monster.monsterName} não conseguiu se defender do ataque de {players[iPlayers].name} e perdeu 5 HP.");
            if (monster.healthPointMonster != 0){
                Console.WriteLine($"{monster.monsterName} está agora com {monster.healthPointMonster} de HP.");
            } else {
                if (player1.alive == false){ //Colocando um "in memoriam" na mensagem de vitória para caso um dos jogadores tenha morrido.
                Console.WriteLine($"O monstro {monster.monsterName} foi derrotado. A equipe {player1.name} (in  memorian) e {player2.name} venceu a partida. Parabéns!");
               break;
            } else if(player2.alive == false){
                Console.WriteLine($"O monstro {monster.monsterName} foi derrotado. A equipe {player1.name} e    {player2.name} (in memorian) venceu a partida. Parabéns!");
                break;
            } else{
                Console.WriteLine($"O monstro {monster.monsterName} foi derrotado. A equipe {player1.name} e    {player2.name} venceu a partida. Parabéns!");
                break;
            }    
            }
        }
    } else {
        Console.WriteLine(@$"O jogador {players[iPlayers].name} acertou um golpe crítico no monstro {monster.monsterName}.");
        if (player1.alive == false){ //Colocando um "in memoriam" na mensagem de vitória para caso um dos jogadores tenha morrido.
            Console.WriteLine($"O monstro {monster.monsterName} foi derrotado. A equipe {player1.name} (in memorian) e {player2.name} venceu a partida. Parabéns!");
            break;
        } else if(player2.alive == false){
            Console.WriteLine($"O monstro {monster.monsterName} foi derrotado. A equipe {player1.name} e {player2.name} (in memorian) venceu a partida. Parabéns!");
            break;
        } else{
            Console.WriteLine($"O monstro {monster.monsterName} foi derrotado. A equipe {player1.name} e {player2.name} venceu a partida. Parabéns!");
            break;
        }        
    }

    //Verificação de morte.
    if (player1.alive == false && player2.alive == false){
        Console.WriteLine($"A equipe {player1.name} e {player2.name} foi derrotada. O monstro {monster.monsterName} venceu a partida.");
        break;
    }
    //Declarando que um player morreu e não pode mais ser chamado para batalha.
    int target = monster.Target();
    if (player1.alive == false){
        target = 1;
    }
    if (player2.alive == false){
        target = 0;
    }
    //Vez do monstro.  
    Console.WriteLine();
    Console.WriteLine(@$"A vez é do monstro {monster.monsterName}.
    O monstro irá atacar {players[target].name}.
    ");
    
    int diceMonster = monster.MonsterDice();
    
    if (diceMonster == 1){
        monster.healthPointMonster = monster.healthPointMonster - 5;
        Console.WriteLine($"O monstro {monster.monsterName} cometeu um erro crítico na realização de seu golpe e perdeu 5 HP.");
        if (monster.healthPointMonster != 0){
            Console.WriteLine($"{monster.monsterName} está agora com {monster.healthPointMonster} de HP.");
        } else {
            if (player1.alive == false){ //Colocando um "in memoriam" na mensagem de vitória para caso um dos jogadores tenha morrido.
                Console.WriteLine($"O monstro {monster.monsterName} foi derrotado. A equipe {player1.name} (in memorian) e {player2.name} venceu a partida. Parabéns!");
                break;
            } else if(player2.alive == false){
                Console.WriteLine($"O monstro {monster.monsterName} foi derrotado. A equipe {player1.name} e {player2.name} (in memorian) venceu a partida. Parabéns!");
                break;
            } else{
            Console.WriteLine($"O monstro {monster.monsterName} foi derrotado. A equipe {player1.name} e {player2.name} venceu a partida. Parabéns!");
            break;
            }
        }
    } else if (diceMonster > 1 && diceMonster < 10){
        Console.WriteLine($"O monstro {monster.monsterName} errou o golpe.");
    } else if (diceMonster >= 10 && diceMonster < 20){
        Console.WriteLine($"O monstro {monster.monsterName} desferiu um golpe contra o jogador, que tentará se defender.");
        int defenseValue = player1.Dice();
            if (defenseValue > diceMonster || defenseValue == diceMonster){
                Console.WriteLine($"O jogador {players[target].name} se defendeu do golpe.");
            } else {
                players[target].healthPoint = players[target].healthPoint - 5;
                Console.WriteLine(@$"O jogador {players[target].name} não conseguiu se defender, sendo acertado pelo monstro e perdendo 5 de HP.");
                if (players[target].healthPoint != 0){
                    Console.WriteLine($"{players[target].name} está agora com {players[target].healthPoint} de HP.");
                } else{
                    Console.WriteLine($"O jogador {players[target].name} morreu.");
                    players[target].alive = false;
            }
        }
    } else {
        Console.WriteLine(@$"O monstro {monster.monsterName} acertou um golpe crítico no jogador {players[target].name}.
        O jogador {players[target].name} morreu.
        ");
        players[target].alive = false;
    }
    
    //Trocando de jogador.
    if (iPlayers == 1){
        iPlayers = 0;
    } else {
        iPlayers = 1;
    }
    //Declarando que um player morreu e não pode mais ser chamado para batalha.
    if (player1.alive == false){
        iPlayers = 1;
    }
    if (player2.alive == false){
        iPlayers = 0;
    }

    if (player1.alive == false && player2.alive == false){
        Console.WriteLine($"A equipe {player1.name} e {player2.name} foi derrotada. O monstro {monster.monsterName} venceu a partida.");
        break;
    }

    Console.WriteLine();
    Console.WriteLine(@$"A vez é do jogador {players[iPlayers].name}.
    ");
}