string resposta = "", vencedor = "", textoDificuldade = "";
int numeroPlayer = 0, numeroMaquina = 0, pontuacaoPlayer = 0, pontuacaoMaquina = 0; 
int teste = 0, rodada = 0;
int dificuldade = 1, respostaDificuldade = 0;
int limitesPontoPlayer = 5, limitesPontoMaquina = 5;
int identificaVitoria = 0;
bool modoFacil = true;
 
Loop();
void Loop(){
    if (rodada == 0){
        Dificuldade();
    }
    Tela();
    Maquina();
    Comparador();
    if (pontuacaoPlayer < limitesPontoPlayer && pontuacaoMaquina < limitesPontoMaquina){
        Loop();
    }
    else if (pontuacaoPlayer == limitesPontoPlayer){
        Pontuacao();
        vencedor = "Você ganhou";
        Console.ResetColor();
    }
    else {
        identificaVitoria = 1;
        Pontuacao();
        vencedor = "Você perdeu";
        Console.ResetColor();
    }
}

if (identificaVitoria == 0) Console.ForegroundColor = ConsoleColor.Magenta;
else Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine($"{vencedor}");
Console.ResetColor();

void Tela(){
    rodada++;
    Pontuacao();
    ExibeComandos();
    Console.ForegroundColor = ConsoleColor.DarkGray;
    resposta = Console.ReadLine()!;
    Console.ResetColor();
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
    if (modoFacil){
        if (rodada >= 2){
            if (teste == numeroMaquina){
                Maquina();
            }
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
    Console.BackgroundColor = ConsoleColor.Gray;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine("‹ Pedra ↔ Papel ↔ Tesoura ›\n");
    Console.ResetColor();
    Console.Write("Pontuação Máquina: ");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"{pontuacaoMaquina}");
    Console.ResetColor();
    Console.Write("Pontuação Player: ");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine($"{pontuacaoPlayer}\n");
    Console.ResetColor();
}

void Dificuldade(){
    Pontuacao();
    DemonstraDificuldade();
    Console.ForegroundColor = ConsoleColor.DarkGray;
    textoDificuldade = Console.ReadLine();
    Console.ResetColor();
    if (!int.TryParse(textoDificuldade, out respostaDificuldade)){
        Console.WriteLine("Impossível converter, tente novamente...");
        Console.ReadKey();
        Dificuldade();
    }
    else if (respostaDificuldade <= 0 || respostaDificuldade > 3){
        Console.WriteLine("Numero incorreto, tente novamente...");
        Console.ReadKey();
        Dificuldade();
    }
    switch(respostaDificuldade){
        case 2:
        modoFacil = false;
        break;
        case 3:
        modoFacil = false;
        limitesPontoPlayer = 10;
        break;
    }
}

void DemonstraDificuldade(){
    Console.WriteLine("Escolha a dificuldade: \n");
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine("1. Nutela †");
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("2. Raíz ⟡");
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine("3. Portões do inferno ☠\n");
    Console.ResetColor();
}

void ExibeComandos(){
    Console.WriteLine("+-----------+-----------+-------------+");
    Console.WriteLine("|     0     |     1     |      2      |");
    Console.WriteLine("+-----------+-----------+-------------+");
    Console.WriteLine("|   Pedra   |   Papel   |   Tesoura   |");
    Console.WriteLine("+-----------+-----------+-------------+");
    Console.WriteLine();
}