string resposta = "", vencedor = "";
int numeroPlayer = 0, numeroMaquina = 0, pontuacaoPlayer = 0, pontuacaoMaquina = 0; 
int teste = 0, rodada = 0;
int dificuldade = 1, respostaDificuldade = 0;
 
Loop();
void Loop(){
    Dificuldade();
    Tela();
    Maquina();
    Comparador();
    if (pontuacaoPlayer < 5 && pontuacaoMaquina < 5){
        Loop();
    }
    else if (pontuacaoPlayer == 5){
        Pontuacao();
        vencedor = "Você ganhou";
    }
    else {
        Pontuacao();
        vencedor = "Você perdeu";
    }
}

Console.WriteLine($"{vencedor}");

void Tela(){
    rodada++;
    Pontuacao();
    Console.WriteLine("0. Pedra 1. Papel 2. Tesoura");
    resposta = Console.ReadLine()!;
    if (!int.TryParse(resposta, out numeroPlayer)){
        Console.WriteLine("Impossível converter, tente novamente...");
        Console.ReadKey();
        Tela();
    }
    else if (numeroPlayer < 0 || numeroPlayer > 2){
        Console.WriteLine("Numero incorreto, tente novamente...");
        Console.ReadKey();
        Tela();
    }
}

void Maquina(){
    int random = new Random().Next(0, 3);
    teste = random;
    if (rodada >= 2){
        if (teste == numeroMaquina){
            Maquina();
        }
    }
    numeroMaquina = teste;
}

void Comparador(){
    if (numeroPlayer == 0 && numeroMaquina == 1){
        pontuacaoMaquina++;
        Console.WriteLine("\nPonto da máquina");
        Thread.Sleep(500);
    }
    else if (numeroPlayer == 0 && numeroMaquina == 2){
        pontuacaoPlayer++;
        Console.WriteLine("\nPonto do jogador");
        Thread.Sleep(500);
    }
    else if (numeroPlayer == 1 && numeroMaquina == 0){
        pontuacaoPlayer++;
        Console.WriteLine("\nPonto do jogador");
        Thread.Sleep(500);
    }
    else if (numeroPlayer == 1 && numeroMaquina == 2){
        pontuacaoMaquina++;
        Console.WriteLine("\nPonto da máquina");
        Thread.Sleep(500);
    }
    else if (numeroPlayer == 2 && numeroMaquina == 0){
        pontuacaoMaquina++;
        Console.WriteLine("\nPonto da máquina");
        Thread.Sleep(500);
    }
    else if (numeroPlayer == 2 && numeroMaquina == 1){
        pontuacaoPlayer++;
        Console.WriteLine("\nPonto do jogador");
        Thread.Sleep(500);
    }
    else {
        Console.WriteLine("\nEmpate");
        Thread.Sleep(500);
    }
}

void Pontuacao(){
    Console.Clear();
    Console.WriteLine("=> Pedra - Papel - Tesoursa <=\n");
    Console.WriteLine($"Pontuação Máquina: {pontuacaoMaquina}");
    Console.WriteLine($"Pontuação Player: {pontuacaoPlayer}\n");
}

void Dificuldade(){
    Pontuacao();
    Console.WriteLine("Escolha a dificuldade: 1. 2.");
    respostaDificuldade = Convert.ToInt32(Console.ReadLine());
}