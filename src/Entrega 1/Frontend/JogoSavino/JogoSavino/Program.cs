using System;
using System.Threading;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;

int Points = 0;
int Energy = 10;
string Nome = null;
bool SpecialMessage1 = false;
while (true)
{
    Console.WriteLine("Bem vindo ao jogo! Você começa com um total de " + Points + " pontos, precisando chegar a 3 para finalizar o jogo, finalizando os 3 atos para conseguí-los. E começa com um total de " + Energy + " de Energia. Caso chegue a 0 de Energia. Você perde. Caso digite ''Desisto'' em qualquer cena de tensão (Momentos que você pode perder Energia ou ganhar pontos), o jogo acaba em uma derrota. Esse jogo é de narrativa, e a cada momento de tensão na narrativa , a quantidade de pontos e de energia que você tem irá aparecer. Boa sorte.");
    Console.WriteLine("========================================================================================================================");
    TypeMessage("ATO 1 - PESQUISA | 23:00 - 00:00", 100);
    Console.WriteLine("========================================================================================================================");
    TypeMessage("''... e então, seu objetivo finalmente foi realizado, você finalmente-''", 15);
    TypeMessage("*click*", 15);
    TypeMessage("Você acorda, exatamente onde você estava da última vez, no laboratório de informática da faculdade. Acabou dormindo naquela aula chata, faz parte. Mas parece que esqueceram de você aqui dentro, e a porta está trancada.", 15);
    TypeMessage("Está tudo tão escuro, as únicas luzes visíveis vêm da placa de vídeo dos computadores. Pelo visto, você tem sorte, pois não desligaram a energia. Você liga o primeiro computador para se logar, e pesquisar em algum browser sobre ''Como sair de uma sala trancada''...", 15);
    TypeMessage("- Carregando... -", 15);
    TypeMessage("- Carregado! -", 15);
    TypeMessage("- Login (Digite seu Nome): -", 15);
    while (string.IsNullOrWhiteSpace(Nome))
    {
        Nome = Console.ReadLine();
        TypeMessage("- Verificando... -", 15);
        Console.WriteLine(Nome);
        if (string.IsNullOrWhiteSpace(Nome))
            TypeMessage("- Login Inválido. Digite seu Nome. -", 15);
        else
            TypeMessage("- Login Aceito! Bem vindo, " + Nome + "! -", 15);
    }
    TypeMessage("Você faz seu login, imediatamente abre seu browser favorito. Hora de fazer a sua pesquisa. O que você vai pesquisar?", 15);
    TypeMessage("- Pergunte ao Browser ou digite um URL (Não digite URLs mesmo) -", 15);
    Console.WriteLine("Pontos: " + Points);
    Console.WriteLine("Energia: " + Energy);
    string PerguntaInicial = null;
    while (PerguntaInicial != "COMO SAIR DE UMA SALA TRANCADA")
    {
        VerifyIfDead(Energy);
        if (Energy <= 0) break;
        PerguntaInicial = Console.ReadLine().ToUpper();
        if (PerguntaInicial == "DESISTO")
            GiveUp();
        else if (PerguntaInicial != "COMO SAIR DE UMA SALA TRANCADA")
        {
            TypeMessage("- Aproximadamente 67.000.000 resultados. Mas nenhum relevante o suficiente para te ajudar a sair. -", 15);
            TypeMessage("Um tempo se passa, e seu corpo começa a ceder. -1 Energia", 15);
            Energy--;
            Console.WriteLine("Energia: " + Energy);
        }
        else break;
    }
    TypeMessage("Você pesquisa ''Como sair de uma sala trancada'' em seu Browser, estes são os resultados...", 15);
    TypeMessage("- Aproximadamente 10.500.000 resultados -", 15);
    TypeMessage("- Instruções:", 15);
    TypeMessage("- 1: Verificar se a porta está trancada. Após um dia cansativo, é comum as pessoas deixarem passar algo óbvio, verificar duas vezes se cansar-se a mais é realmente necessário deve ser o primeiro passo para seu problema. -", 15);
    TypeMessage("- 2: Procurar uma chave reserva ao redor. É sempre bom tomar medidas preventivas em situações de perigo. Uma chave reserva deve ser uma das ideias mais otimizadas para segurança. -", 15);
    TypeMessage("- 3: Tentar encontrar outras saídas. Sempre tem a chance da porta principal emperrar ou ter algum outro tipo de problema. Verifique por janelas, dutos de ventilação, ou quaisquer outras saídas que o local possa ter. Seja criativo! -", 15);
    TypeMessage("- 4: Gritar por ajuda o mais alto que pode. Humanos são solidários uns com os outros, com certeza alguém que tiver ouvindo seu pedido de ajuda fará o máximo que pode para lhe salvar. -", 15);
    TypeMessage("Após calmamente ler as instruções, você tira um momento para observar a sala que você está. Você tem a chance de tentar qualquer uma das alternativas instruídas acima. O que tentará? (Responda com 1, 2, 3, ou 4)", 15);
    Console.WriteLine("Pontos: " + Points);
    Console.WriteLine("Energia: " + Energy);
    int n = 0;
    while (n != 2 && n != 3 && n != 4)
    {
        n = int.Parse(Console.ReadLine());
        if (n != 1 && n != 2 && n != 3 && n != 4)
        {
            TypeMessage("Opção inválida, tente novamente.", 15);
        }
        else if (n == 1)
            TypeMessage("Você verifica se a porta está trancada. E é óbvio que está. Se não tivesse, não teria desafio nenhum, afinal. Escolha outra opção.", 15);
        else if (n == 4)
            TypeMessage("Você grita extremamente alto. É cansativo ter que forçar a voz enquanto cansado às 23h30, mas você não recebe uma resposta. Escolha outra opção.", 15);
        else break;
    }
    if (n == 2)
    {
        CaminhoA();
    }
    else if (n == 3)
    {
        CaminhoB();
    }

    static void TypeMessage(string message, int delay) // Message Typer
    {
        bool skip = false;

        for (int i = 0; i < message.Length; i++)
        {
            if (Console.KeyAvailable) // Check if the user pressed a key
            {
                var key = Console.ReadKey(intercept: true); // intercept: true hides the pressed key from printing
                if (key.Key == ConsoleKey.Enter)
                {
                    skip = true;
                }
            }

            if (skip)
            {
                Console.Write(message.Substring(i));
                break;
            }

            Console.Write(message[i]);
            Thread.Sleep(delay);
        }

        Console.WriteLine();
    }

    void CaminhoA()
    {
        TypeMessage("Você anda pelo laboratório de informática. Procura entre computadores, no vão da lousa, na caixa de som, de baixo da porta (por que não?), e na mesa do professor. Lá, é possível encontrar uma pequena gaveta que, por incrível que pareça, está aberta.", 15);
        TypeMessage("Dentro dela, você encontra uma quantidade impressionante de clips, canetas, e papéis com algumas anotações. Hora de procurar essa sua prova para saber as respostas e poder tirar a nota máxima! Não, você está muito cansado para isso. Lá, você também encontra um estojo extremamente pesado. Deve ser o suficiente para quebrar o vidro da porta. O que gostaria de fazer? (Responda com 1 ou 2)", 15);
        TypeMessage("1 - Pegar um punhado de clips e procurar na internet instruções de como destrancar uma fechadura com um clips.", 15);
        TypeMessage("2 - Pegar o estojo pesado e jogá-lo com tudo contra o vidro da porta.", 15);

        Console.WriteLine("Pontos: " + Points);
        Console.WriteLine("Energia: " + Energy);

        int n = 0;
        while (n != 1 && n != 2)
        {
            n = int.Parse(Console.ReadLine());
            if (n != 1 && n != 2)
            {
                TypeMessage("Opção inválida, tente novamente.", 15);
            }
            else if (n == 1)
            {
                TypeMessage("Você pega esse punhado de clips, e volta para seu computador. Pesquisando - Como destrancar uma fechadura com um clips. -", 15);
                TypeMessage("- Fechaduras têm suas próprias trancas, as quais você precisa apertar em uma ordem específica que nunca muda, mas para cada tranca é uma. -", 15);

                Random random = new Random();
                int[] Answer = new int[5];
                for (int i = 0; i < Answer.Length; i++)
                {
                    Answer[i] = random.Next(1, 7);
                }

                string Result = string.Join("", Answer);
                string GivenAnswer = "";

                while (Result != GivenAnswer && Energy > 0)
                {
                    Console.WriteLine("Energia: " + Energy);
                    Console.Write("Senha: ");
                    GivenAnswer = Console.ReadLine();

                    if (GivenAnswer.Length != Answer.Length || !GivenAnswer.All(char.IsDigit))
                    {
                        Console.WriteLine($"Por favor, digite exatamente {Answer.Length} números!");
                        continue;
                    }

                    if (Result != GivenAnswer)
                    {
                        Energy--;
                        string[] feedback = new string[Answer.Length];
                        for (int i = 0; i < Answer.Length; i++)
                        {
                            int numeroDigitado = int.Parse(GivenAnswer[i].ToString());
                            int numeroCerto = Answer[i];
                            if (numeroDigitado > numeroCerto)
                            {
                                feedback[i] = "Tuk"; // Maior
                            }
                            else if (numeroDigitado < numeroCerto)
                            {
                                feedback[i] = "Tek"; // Menor
                            }
                            else
                            {
                                feedback[i] = "Tik"; // Certo
                            }
                        }

                        TypeMessage(string.Join(", ", feedback), 10);
                        Console.WriteLine("Energia: " + Energy);
                        VerifyIfDead(Energy);
                    }
                }

                if (Energy > 0)
                {
                    TypeMessage("\nTik, Tik, Tik, Tik, Tik", 15);
                    Console.WriteLine("Energia: " + Energy);
                    TypeMessage("E você ouve a porta se destrancando por completo. Você está cansado, mas continua bem, sem nenhum tipo de ferimento. Imagina o que poderia acontecer se você tacasse aquele estojo nessa porta...", 15);
                    TypeMessage("Você finalmente abre a porta, e continua, determinado. Saiu da sala com sucesso, agora precisa sair da faculdade.", 15);
                    Points++;
                    Ato2();
                }
            }
            else if (n == 2)
            {
                TypeMessage("Você pega, fazendo muita força, aquele maldito estojo, estabiliza-o com as duas mãos, e taca-o contra o vidro daquela porta...", 15);
                TypeMessage("CLINK", 10);
                TypeMessage("...e ele trinca. Após fazer isso uma segunda vez, ele se racha por completo, espalhando estilhaços de vidro no chão, que parece muito perigoso de pisar. Agora Você pode sair. Você caminha cautelosamente até a porta, mas por falta de atenção, se corta, fazendo um grande ferimento. Você continua, determinado. Saiu da sala com sucesso, agora precisa sair da faculdade.", 15);
                Points++;
                Energy -= 3;
                VerifyIfDead(Energy);
                Ato2();
            }
        }
    }


    void CaminhoB()
    {
        Energy = 0;
        TypeMessage("Você procura por outras saídas, tenta ser criativo, e encontra uma pequena janela quadrada. Pega com muito esforço alguns gabinetes dos primeiros computadores que você encontra, e os empilha. Com muita esperança, abre a janela e pula! FInalmente livre! Não, você não viu a altura da queda. A queda é fatal, e acaba em sua morte.", 15);
        Console.WriteLine("Energia: " + Energy);
        SpecialMessage1 = true;
        VerifyIfDead(Energy);
    }

    void Ato2() // COMEÇAR ATO 2
    {
        Console.WriteLine("========================================================================================================================");
        Console.WriteLine("Pontos: " + Points);
        Console.WriteLine("Energia: " + Energy);
        Console.WriteLine("========================================================================================================================");
        TypeMessage("ATO 2 - EXPLORAÇÃO | 00:00 - 01:00", 100);
        Console.WriteLine("========================================================================================================================");
    }

    void VerifyIfDead(int energy) // Verifies if the player died
    {
        if (energy <= 0)
        {
            YouLose();
        }

    }

    void YouLose()
    {
        if (SpecialMessage1)
        {
            TypeMessage("Passa-se um bom tempo. Ninguém havia encontrado sinais do corpo, até que ele começa a feder. A sua morte começa a viralizar nas notícias. Pessoas choram, riem, e alguns não se importam o suficiente. A polícia não tem informações suficientes de como isso foi acontecer, por mais que veem uma janela aberta alguns bons metros acima do corpo. A morte é datada como suicídio. Derrota.", 15);
            Console.WriteLine("========================================================================================================================");
        }
        else
        {
            TypeMessage("Seu corpo cede, muito tempo se passou desde quando você ficou preso por aqui. A fome, sede, cansaço, ou sono lhe venceram, e você desmaia. Acordando somente no próximo dia, na aula do próximo professor a noite. Perdendo seu dia de trabalho e sendo demitido. Derrota.", 15);
            Console.WriteLine("========================================================================================================================");
        }
    }

    static void GiveUp()
    {
        TypeMessage("Muito trampo... você digita uma mensagem para o seu chefe falando que não poderá comparecer no próximo dia, e vai dormir em uma cadeira. Você acorda no próxximo dia de manhãnormalmente. Não a tempo de ir ao trabalho, mas a tempo de pedir para algum segurança do período matutino te tirar da sala e você poder voltar para a sua casa e comer algo normalmente. Derrota", 15);
    }
    return;
}