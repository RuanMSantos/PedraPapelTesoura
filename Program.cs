string resposta = "", vencedor = "", textoDificuldade = "", respostaDescricao = "";
int numeroPlayerTemporario = 0, numeroMaquina = 0, pontuacaoPlayer = 0, pontuacaoMaquina = 0; 
int teste = 0, rodada = 0;
int dificuldade = 1, respostaDificuldade = 0;
int limitesPontoPlayer = 5, limitesPontoMaquina = 5;
int identificaVitoria = 0;
int numeroPlayer = 0;
bool modoFacil = true, impossivel = false;

string nutela = "\nA máquina não pode repetir as jogadas duas vezes seguidas, porém, você pode. => Valor para vitória: 5 para os dois.\n";
string raiz = "Os dois podem repetir a jogada. => Valor para vitória: 5 para os dois.\n";
string portoesDoInferno = "Os dois podem repetir a jogada, entretanto... O inferno é injusto. => Valor para vitória: 5 para máquina e 10 para você.\n";
string soParaHackers = "Você não pode repetir as mesmas jogadas seguidas, podemos dizer que são duas injustiças seguidas... => Valor para vitória: 5 para máquina e 15 para você.\n\n";
 
Loop();
void Loop(){
    if (rodada == 0){
        Dificuldade();
    }
    rodada++;
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
    Pontuacao();
    ExibeComandos();
    Console.ForegroundColor = ConsoleColor.DarkGray;
    resposta = Console.ReadLine()!;
    Console.ResetColor();
    if (!int.TryParse(resposta, out numeroPlayerTemporario)){
        Console.WriteLine("Impossível converter, tente novamente...");
        Console.ReadKey();
        Tela();
    }
    else if (numeroPlayerTemporario < 0 || numeroPlayerTemporario > 2){
        Console.WriteLine("Numero incorreto, tente novamente...");
        Console.ReadKey();
        Tela();
    }
    if(impossivel){
        if(rodada >= 2){
            if (numeroPlayer == numeroPlayerTemporario){
                Console.WriteLine("Impossível fazer a mesma jogada duas vezes seguidas...");
                Console.ReadKey();
                Tela();
            }
        }
    }
    numeroPlayer = numeroPlayerTemporario ;
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
    if (numeroPlayerTemporario == 0 && numeroMaquina == 1){
        pontuacaoMaquina++;
        Console.WriteLine("\nPonto da máquina");
        Thread.Sleep(500);
    }
    else if (numeroPlayerTemporario == 0 && numeroMaquina == 2){
        pontuacaoPlayer++;
        Console.WriteLine("\nPonto do jogador");
        Thread.Sleep(500);
    }
    else if (numeroPlayerTemporario == 1 && numeroMaquina == 0){
        pontuacaoPlayer++;
        Console.WriteLine("\nPonto do jogador");
        Thread.Sleep(500);
    }
    else if (numeroPlayerTemporario == 1 && numeroMaquina == 2){
        pontuacaoMaquina++;
        Console.WriteLine("\nPonto da máquina");
        Thread.Sleep(500);
    }
    else if (numeroPlayerTemporario == 2 && numeroMaquina == 0){
        pontuacaoMaquina++;
        Console.WriteLine("\nPonto da máquina");
        Thread.Sleep(500);
    }
    else if (numeroPlayerTemporario == 2 && numeroMaquina == 1){
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
    LiberacaoDescricao();
    DemonstraDificuldade();
    Console.ForegroundColor = ConsoleColor.DarkGray;
    textoDificuldade = Console.ReadLine();
    Console.ResetColor();
    if (!int.TryParse(textoDificuldade, out respostaDificuldade)){
        Console.WriteLine("Impossível converter, tente novamente...");
        Console.ReadKey();
        Dificuldade();
    }
    else if (respostaDificuldade <= 0 || respostaDificuldade > 4){
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
        case 4:
        modoFacil = false;
        limitesPontoPlayer = 15;
        impossivel = true;
        break;
    }
}

void DemonstraDificuldade(){
    Console.WriteLine("\nEscolha a dificuldade: \n");
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine("1. Nutela †");
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("2. Raíz ⟡");
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine("3. Portões do inferno ☠");
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("4. Só para hackers ☻\n");
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

void Descricao(){
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    for (int i = 0; i < nutela.Length; i++){
        char caractere = nutela[i];
        Thread.Sleep(25);
        Console.Write(caractere);
    }
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    for (int i = 0; i < raiz.Length; i++){
        char caractere = raiz[i];
        Thread.Sleep(25);
        Console.Write(caractere);
    }
    Console.ForegroundColor = ConsoleColor.DarkRed;
    for (int i = 0; i < portoesDoInferno.Length; i++){
        char caractere = portoesDoInferno[i];
        Thread.Sleep(25);
        Console.Write(caractere);
    }
    Console.ForegroundColor = ConsoleColor.Blue;
    for (int i = 0; i < soParaHackers.Length; i++){
        char caractere = soParaHackers[i];
        Thread.Sleep(25);
        Console.Write(caractere);
    }
    Console.ResetColor();
}

void LiberacaoDescricao(){
    Console.Write("Quer uma descrição para entender com o que está lidando?[s/n] ");
    respostaDescricao = Console.ReadLine()!.ToLower().Trim();
    if(respostaDescricao != "s" && respostaDescricao != "n"){
        Thread.Sleep(500);
        Console.Write("\n\nboing! ");
        Thread.Sleep(500);
        Console.WriteLine("RESPOSTA ERRADA!");
        Thread.Sleep(500);
        Console.WriteLine("\nPressione uma tecla para tentar novamente...");
        Console.ReadKey();
        Dificuldade();
 
    }
    if (respostaDescricao == "s"){
        Descricao();
        Console.WriteLine("Pressione uma tecla para continuar...");
        Console.ReadKey();
    }
}