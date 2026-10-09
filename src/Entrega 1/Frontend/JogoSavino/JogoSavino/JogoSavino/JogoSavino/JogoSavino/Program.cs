using System;
using System.Threading;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;

int Points = 0;
int Energy = 10;
string Nome = null;
bool SpecialMessage1 = false;
int Rota = 0;
int trajeto = 0;
bool CodigoEncontrado = false;
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
    while (n != 2 && n != 3)
    {
        string input = (Console.ReadLine().Trim().ToUpper());
        { if (input == "DESISTO")
                GiveUp();
        }

        if (int.TryParse(input, out n))
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
            string input = (Console.ReadLine().ToUpper());
            {
                if (input == "DESISTO")
                    GiveUp();
            }

            if (int.TryParse(input, out n))
            if (n != 1 && n != 2)
            {
                TypeMessage("Opção inválida, tente novamente.", 15);
            }
            else if (n == 1)
            {
                TypeMessage("Você pega esse punhado de clips, e volta para seu computador. Pesquisando - Como destrancar uma fechadura com um clips. -", 15);
                TypeMessage("- Fechaduras têm suas próprias trancas, as quais você precisa apertar em uma ordem específica que nunca muda, mas para cada tranca é uma. -", 15);
                Console.WriteLine("(MECANICAMENTE: Para descobrir, você precisa acertar 5 dígitos de 1 a 6. O sistema irá lhe responder com uma série de onomatopeias que podem significar uma de três coisas:");
                Console.WriteLine("1 - O número digitado é MAIOR do que aquele que você quer descobrir.");
                Console.WriteLine("2 - O número digitado é MENOR do que aquele que você quer descobrir.");
                Console.WriteLine("3 - O número digitado É aquele que você quer descobrir.");
                Console.WriteLine("Simples assim! Não é? ...ok, talvez seja um pouco complicado. Vamos fazer uma rodada de exemplo.");
                Console.WriteLine("Nesse nosso exemplo, a senha correta será 12345. A onomatopeia de 'Maior' será 'Blam', a de 'Menor' será 'Blem', e 'Certo' será 'Blim', os significados NUNCA irão mudar no meio do jogo. Se você chutar a senha 33333, o primeiro número que você quer é maior do que o que você digitou. Maior é 'Blam', então para esse número você receberia 'Blam'. O chute todo ficaria 'Maior, Maior, Certo, Menor, Menor'. Resultando em 'Blam, Blam, Blim, Blem, Blem'. Nesse caso, você saberá que está tudo certo se seu chute ficar 'Blim, Blim, Blim, Blim, Blim' e a história continuar, é porque está certo. É parte de seu objetivo descobrir qual onomatopeia está associada a qual significado para descobrir a senha aleatória! Boa sorte.");
                Random random = new Random();
                string[] Answer = new string[5];
                for (int i = 0; i < Answer.Length; i++)
                {
                    Answer[i] = random.Next(1, 7).ToString();
                }

                string Result = string.Join("", Answer);
                string GivenAnswer = "";

                    while (Result != GivenAnswer && Energy > 0)
                    {
                        Console.WriteLine("Energia: " + Energy);
                        Console.Write("Senha: ");
                        GivenAnswer = Console.ReadLine().ToUpper();
                        if (GivenAnswer == "DESISTO")
                        {
                            GiveUp();
                            continue;
                        }
                                        
                        

                        else if (GivenAnswer.Length != Answer.Length || !GivenAnswer.All(char.IsDigit))
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
                                int numeroCerto = int.Parse(Answer[i].ToString());
                            if (numeroDigitado > numeroCerto)
                            {
                                feedback[i] = "Blem"; // Maior
                            }
                            else if (numeroDigitado < numeroCerto)
                            {
                                feedback[i] = "Blam"; // Menor
                            }
                            else
                            {
                                feedback[i] = "Blim"; // Certo
                            }
                        }

                        TypeMessage(string.Join(", ", feedback), 10);
                        VerifyIfDead(Energy);
                    }
                }

                if (Energy > 0)
                {
                    TypeMessage("\nBlim, Blim, Blim, Blim, Blim", 15);
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
        TypeMessage("Olhando ao redor, um andar escuro. Ao ir até o interruptor do andar e tentar ligar as luzes, nada acontece. Talvez a caixa de energia fonte da faculdade tenha sido desligada para salvar energia. Ao olhar com um pouco mais de atenção, você encontra um elevador, que você deduz que também não estará funcionando, já que as energias foram interrompidas. Há também algumas escadas, com uma faixa preta e amarela entre você e elas, devem estar interditadas. Você leva seu tempo para averiguar o andar inteiro. Essas parecem ser as únicas maneiras de sair, realmente. Seu novo objetivo é claro: Ligar a caixa de energia fonte e ir de elevador ou contornar as escadas e qualquer problema que resultou nelas serem interditadas e ir de escada.", 15);
        TypeMessage("Mas, antes de tudo, a escolha é sua. Gostaria de ir para a rota do elevador, ou a rota da escada?", 15);
        Console.WriteLine("1 = Elevador");
        Console.WriteLine("2 = Escada");
        while(true)
        {
            TypeMessage("Digite 1 para elevador ou 2 para Escada", 15);

            if (!int.TryParse(Console.ReadLine(), out Rota) || (Rota != 1 && Rota != 2))
            {
                TypeMessage("Opção inválida. Digite 1 para a rota do elevador ou 2 para a rota da escada.", 15);
                continue;
            }

            if (Rota == 1)
            {
                TypeMessage("Você vai até os elevadores, as portas estão fechadas e você aperta o botão para chamar o elevador, obviamente não acontece nada, você aperta de novo, espera alguns segundos, e nada. Os elevadores obviamente não funcionam porque o prédio está sem energia. Tente pelas escadas.", 15);
                continue;
            }

            RotaEscada();
            break;
        }
    }

    void RotaEscada() // Continuar escrevendo aqui a rota da escada
    {
        TypeMessage("Ao prestar melhor atenção nas escadas, você percebe que está atualmente no primeiro andar. Você sabe que a saída é no quarto andar. Porém, são exatamente as escadas que levam para cima que estão interditadas. Sua única opção é descer.", 15);
        TypeMessage("Antes de descer, olha ao redor, e vê uma placa de diretório de andares logo ao seu lado. Observando o que há para baixo, somente o andar zero, o qual geralmente só funcionários podem ir. Ele serve para manutenção, ferramentas, e limpeza.", 15);
        TypeMessage("...Não é como se mais alguém tivesse aqui para lhe impedir. Você prossegue, entrando no andar zero. A primeira coisa que lhe chama atenção é o forte cheiro de produto de limpeza que se encontra neste andar. Logo após, você finalmente percebe: Esse lugar é imenso. Tem muita sala diferente com muita informação diferente e várias ferramentas para fuçar. E saber que você não sabe mexer em nada disso é um pouco deprimente...", 15);
        TypeMessage("Porém, você identifica o que parece ser um painel de controle. Um quadrado tecnológico com muitos botões que devem ser explorados. Você sabe que se mexer na parte certa, liga a energia. Este conjunto de teclas enumeradas de 0 a 9 e esses quatro espaços em branco devem significar alguma coisa... como se esperasse uma senha.", 15);
        Console.WriteLine("========================================================================================================================");
        TypeMessage("A partir daqui, a narração do local e toda a mecânica de exploração fará parte do enigma do Ato 2. Onde seu objetivo é descobrir a senha correta e colocá-la no painel. O jogo estará funcionando da seguinte maneira: Você começa no painel de controle, e você terá a opção de tentar digitar uma senha (Perde 1 de energia por palpite incorreto) ou de começar/continuar a narração do local. Preste atenção aos detalhes, sabendo que a senha é de quatro caracteres que podem ser de 0 a 9, e que a enumeração da narração é do mais perto de ti para o mais longe. Lembre-se que você sempre pode desistir escrevendo ''Desisto''. Boa sorte.", 2);
        Console.WriteLine("Pontos: " + Points);
        Console.WriteLine("Energia: " + Energy);
        Console.WriteLine("========================================================================================================================");
        string SenhaCorreta = "4823";
        string SenhaTentada = null;
        while (SenhaTentada != SenhaCorreta)
        {
            SenhaTentada = null;
            string Tentar = null;
            Console.Write("Digite 1 para tentar digitar uma senha e 2 para começar/continuar a narração: ");
            Tentar = Console.ReadLine().ToUpper();
            if (Tentar != "1" && Tentar != "2" && Tentar != "DESISTO")
            {
                Console.WriteLine("Opção inválida, tente novamente, digitando 1 ou 2, dependendo do que deseja fazer.");
            }
            else if (Tentar == "DESISTO")
            {
                GiveUp();
            }
            else if (Tentar == "1")
            {
                TypeMessage("Você se aproxima do painel de controle. Sabendo ou não a senha, você vê aqueles quatro espaços em branco, e aquelas teclas numeradas. Escreva a senha de quatro dígitos, ou escreva ''0'' para parar de digitar e voltar. CUIDADO! Cada senha errada, incluindo digitação de letras, ou números com mais ou menos de quatro caracteres, contará como erro e fará você perder 1 de Energia.", 15);
                while (SenhaTentada != "0" && SenhaTentada != SenhaCorreta && SenhaTentada != "DESISTO")
                {
                    Console.Write("SENHA: ");
                    SenhaTentada = Console.ReadLine().ToUpper();
                    if (SenhaTentada == "DESISTO")
                    {
                        GiveUp();
                    }
                    else if (SenhaTentada == "0")
                    {
                        TypeMessage("Após um tempo, você sai do painel, e volta a explorar o andar...", 15);
                    }
                    else if (SenhaTentada == SenhaCorreta)
                    {
                        TypeMessage("Você tenta a senha " + SenhaCorreta + " e aperta no grande botão vermelho ao lado. As luzes subitamente se acendem! Um ânimo recompensante lhe recompensa, agora você pode voltar para o primeiro andar e ir de elevador. Se direcionando ao hall de entrada da faculdade para sair por lá.", 15);
                        Ato3();
                    }
                    else
                    {
                        TypeMessage("Você tenta a senha " + SenhaTentada + " e aperta no grande botão vermelho ao lado. Você espera um tempo, e nada acontece. Senha errada.", 15);
                        Energy--;

                    }
                    Console.WriteLine("Energia: " + Energy);
                }
            }
            else if (Tentar == "2") // AQUI COMEÇA A NARRAÇÃO DO ANDAR
            {
                TypeMessage("Você se vira para explorar o resto do andar. É tanta sala diferente, tanta ferramenta diferente que você não sabe usar e teria de aprender... deve ter um jeito mais fácil. Talvez você só deva prestar mais atenção nas partes mais importantes...", 15);
                TypeMessage("Ao parar (por um bom tempo...) para ver o que há na sala, você consegue organizar o que vê em uma lista. Conferindo-a algumas vezes para garantir que não falta nada. Você anota incessantemente em seu caderno (que convenientemente não tem anotações das matérias de verdade...) e separa o que você vê em ordem de distância, do primeiro ao último. Suas anotações ficaram assim:", 15);
                Console.WriteLine("1: Um grande corredor, com armários estilizados pelas paredes. Parecem ser para armazenamento.");
                Console.WriteLine("2: Uma sala de computadores. Estão todos desligados, você não sabe bem o que fazem por aqui.");
                Console.WriteLine("3: Uma grande caixa elétrica. Com uma pequena fechadura em sua frente. Por sorte, parece semiaberta.");
                Console.WriteLine("4: O banheiro do andar, no fim do corredor. Feminino na esquerda, masculino na direita.");
                Console.Write("Escreva um número de 1 a 4. Representando aonde você vai: ");
                string narracao = Console.ReadLine().ToUpper();
                if (narracao == "DESISTO")
                {
                    GiveUp();
                }
                else if (narracao == "1")
                {
                    TypeMessage("Você então se aproxima do corredor com os armários. Estes parecem ser os armários pessoais de cada funcionário da faculdade, enumerados em ordem. Todos estão devidamente trancados, exceto um que esqueceu, o dono do armário 4. Você decide fuçar o que há dentro do armário, somente uma quantidade sobrenatural de energéticos.", 15);
                }
                else if (narracao == "2")
                {
                    TypeMessage("Você então chega à sala de computadores. Parece ter uns nove, e eles devem estar em modo de descanso, afinal, algo dentro deles ainda brilha, representando que está ligado. É sua memória RAM, de 8 gigabytes. Então é por isso que você demora para abrir aquele programa? Não vale a pena mexer nesses computadores nessa hora.", 15);
                }
                else if (narracao == "3")
                {
                    TypeMessage("Você caminha, até eventualmente chegar à caixa elétrica. Como ela parece semiaberta, você consegue abrí-la por completo para ver o que há dentro. Meia dúzia de botões, três interruptores, 2 alavancas, e uns cinco painéis de instrução. Está dando dor de cabeça só de olhar para isso tudo... você fecha a caixa e sai de perto dela. Hora de buscar os arredores.", 15);
                }
                else if (narracao == "4")
                {
                    TypeMessage("Você vai até o fim do corredor, até se deparar com uma parte mais afastada do andar. Acabou de chegar ao banheiro. Tem a porta feminina na esquerda e a masculina na direita. Você entra na qual lhe encaixa melhor, ou talvez na outra porta (Afinal, quem nunca esteve curioso para saber como é a aparência do outro banheiro?) e começa a procurar por algo que lhe chama a atenção. Você aproveita e lava seu rosto para se manter acordado, se posicionando na pia do meio dentre 3. Após uma busca frenética por algo que nem você sabe o que é, você sai do banheiro.", 15);
                }
                else
                {
                    Console.WriteLine("Opção inválida, tente novamente. Respondendo com ''1'', ''2'', ''3'', ''4'' ou ''Desisto''.");
                }
            }
        }
    }


    void Ato3() //Começar o ATO 3
    {
        Console.WriteLine("========================================================================================================================");
        Console.WriteLine("Pontos: " + Points);
        Console.WriteLine("Energia: " + Energy);
        Console.WriteLine("========================================================================================================================");
        TypeMessage("ATO 3 - EVASÃO | 01:00 - 02:00", 100);
        Console.WriteLine("========================================================================================================================");
        TypeMessage("Você finalmente chega ao hall de entrada da faculdade e agora só te resta sair dela, porém, você tem mais um obstáculo: A porta principal da faculdade, que é a única saída que você conhece, está trancada e você precisa dar um jeito de abrir ela", 15);
        TypeMessage("Você estuda o lugar, pensa onde pode ter alguma chave para abrir aquela porta, olha cada canto... Você finalmente olha para o balcão onde ficam as recepecionistas e em sua cabeça, cria-se a sensação de certeza que ali você acharia algo.", 15);
        TypeMessage("Você vai até o balcão das recepcionistas e embaixo vê um pequeno armário de vidro, você tenta olhar dentro dele, com muita dificuldade porque esta escuro, mas enxerga algo que seria a sua saída daquele lugar, uma chave prateada em formato hexagonal, havia uma fita pendurada á ela com as palavras escritas 'Porta Principal'. Você vê um cadeado com uma senha de 4 dígitos na porta do armário e pensa em duas opções: Tentar socar a porta do armário, mas você se machucará, ou estudar alguma forma de descobrir a senha do armário. O que você faz?", 15);
        Console.WriteLine("1 - Socar com muita força o vidro da pequena porta do armário");
        Console.WriteLine("2 - Estudar alguma forma de descobrir a senha do cadeado");
        while (true)
        {
            if (!int.TryParse(Console.ReadLine(), out trajeto) || (trajeto != 1 && trajeto != 2))
            {
                TypeMessage("Opção Inválida, tente as opções 1 ou 2", 15);
                continue;
            }

            break;
        }

        bool pegouChave = false;

        if (trajeto == 1)
            pegouChave = trajetoBrake();
        else
            pegouChave = trajetoSenha();

        if (pegouChave)
        {
            TypeMessage("Você finalmente pega aquela chave que estava dentro do armário e agora está pronto pra sair daquele lugar. Você pula a catraca e vai até a porta, gira a chave para destrancar a porta e abre ela, você finalmente sente o frescor do ar da madrugada e se sente aliviado. Você, agora fora da faculdade, tranca a porta novamente e joga a chave para o lado de dentro pelo vão debaixo da porta. Finalmente, você sai andando em direção á sua casa, no dia seguinte, você chega à tempo no seu trabalho, e na faculdade, ninguém desconfia de absolutamente nada.", 15);
            TypeMessage("==================================================================================", 15);
            TypeMessage("VITÓRIA!!!", 15);
        }

        bool trajetoSenha()
        {
            TypeMessage("Você para e tenta pensar todas as formas de descobrir a senha daquele cadeado que tranca o armário, e então você começa a passar a mão em diversas partes 'escondidas' da mesa. Ao passar a mão por trás do monitor, você sente um papel, puxa ele e pega para ler oque estava escrito, era uma mensagem entre uma recpecionista e outra e ela dizia:", 15);
            TypeMessage("Mariana! Ñ esqueçe a senha dnv, pfvr!! lembra: A senha é o ano em que eu nasci. Hoje, em 2026, eu tenho o triplo da idade que o meu filho tem, e a soma das nossas idades dá 80 anos.", 15); //Fórmula Filho = x, Mãe = 3x -> x + 3x = 80 -> 4x=80 -> x=20 -> Mãe = 3x20 = 60 -> 2026-60 = 1966

            while (true)
            {
                Console.Write("Digite a senha do cadeado: ");
                string senha = Console.ReadLine();

                if (senha == "1966")
                {
                    TypeMessage("Click! O cadeado abre e você pega a chave hexagonal.", 15);
                    return true;
                }

                Energy -= 1;
                TypeMessage("Nada acontece. A senha está errada. Energia: " + Energy, 15);

                if (Energy < 0)
                {
                    YouLose();
                    return false;
                }
            }
        }

        bool trajetoBrake()
        {
            Energy -= 5;
            TypeMessage("Você soca o vidro daquele armário com toda sua força, sua mão e seus ossos latejam de dor, você soca de novo, fazendo o vidro estourar e cortar sua mão em várias partes. O armário agora estava aberto , você enfia sua mão lá dentro e pega a chave hexagonal", 15);
            return true;
        }
    }
    void VerifyIfDead(int energy) // Verifies if the player died
    {
        if (energy <= 0)
        {
            YouLose();
            Environment.Exit(0);
        }

    }

    void YouLose()
    {
        Console.WriteLine("Energia: " + Energy);
        if (SpecialMessage1)
        {
            TypeMessage("Passa-se um dia. Onde os policiais locais estão fazendo sua vistoria diária em sua rua. Estava tudo indo bem. Até encontrarem você despejado no chão junto a uma poça de sangue. Não sabem exatamente como isso aconteceu, porém avisam a família imediatamente sobre o ocorrido após confirmar a morte. Derrota.", 15);
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
        TypeMessage("Muito trampo... você digita uma mensagem para o seu chefe falando que não poderá comparecer no próximo dia, e vai dormir em uma cadeira. Você acorda no próximo dia de manhã normalmente. Não a tempo de ir ao trabalho, mas a tempo de pedir para algum segurança do período matutino te tirar da sala e você poder voltar para a sua casa e comer algo normalmente. Derrota", 15);;
        Environment.Exit(0);
    }
    return;
}