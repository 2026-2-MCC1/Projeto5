using System;
using System.Threading;
using System.Windows.Input;

int Points = 0;
int Energy = 10;
string Nome = null;
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
    if (n == 2) // CONTINUAR A PARTIR DAQUI
    {

    }
    else if (n == 3) // CONTINUAR AQUI TAMBÉM
    {

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

    static void VerifyIfDead(int energy) // Verifies if the player died
    {
        if (energy <= 0)
        {
            YouLose();
        }

    }

    static void YouLose()
    {
        TypeMessage("Seu corpo cede, muito tempo se passou desde quando você ficou preso por aqui. A fome, sede, cansaço, ou sono lhe venceram, e você desmaia. Acordando somente no próximo dia, na aula do próximo professor a noite. Perdendo seu dia de trabalho e sendo demitido. Derrota.", 15);
        Console.WriteLine("========================================================================================================================");
    }

    static void GiveUp()
    {
        TypeMessage("Muito trampo... você digita uma mensagem para o seu chefe falando que não poderá comparecer no próximo dia, e vai dormir em uma cadeira. Você acorda no próxximo dia de manhãnormalmente. Não a tempo de ir ao trabalho, mas a tempo de pedir para algum segurança do período matutino te tirar da sala e você poder voltar para a sua casa e comer algo normalmente. Derrota", 15);
    }
    return;
}