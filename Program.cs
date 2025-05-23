using System;

namespace LabCelulares
{
    abstract class Celular
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Bateria { get; private set; }

        public Celular(string marca, string modelo)
        {
            Marca = marca;
            Modelo = modelo;
            Bateria = 100;
        }

        public virtual void Ligar()
        {
            Console.WriteLine($"Ligando {Marca} {Modelo}... Tá indo, aguenta firme!");
            ConsumirBateria(5);
        }

        public virtual void Desligar()
        {
            Console.WriteLine($"{Marca} {Modelo} desligando... Até mais!");
        }

        public abstract void MostrarInfo();

        public virtual void TirarFoto()
        {
            Console.WriteLine("Foto tirada. Nada demais, só um clique!");
            ConsumirBateria(3);
        }

        public virtual void FazerLigacao(string numero)
        {
            Console.WriteLine($"Ligando para {numero}... Alô? Quem fala?");
            ConsumirBateria(10);
        }

        public virtual void MandarMensagem(string numero, string texto)
        {
            Console.WriteLine($"Mandando SMS para {numero}: \"{texto}\"");
            ConsumirBateria(2);
        }

        public virtual void AtualizarSistema()
        {
            Console.WriteLine("Atualizando sistema... Esse processo pode demorar um pouco, pega um café.");
            ConsumirBateria(20);
        }

        public void MostrarBateria()
        {
            Console.WriteLine($"Bateria: {Bateria}% restante.");
        }

        protected void ConsumirBateria(int valor)
        {
            Bateria -= valor;
            if (Bateria < 0) Bateria = 0;
        }

        public void Recarregar()
        {
            Console.WriteLine("Carregando bateria... Paciencia, vai ficar 100% logo.");
            Bateria = 100;
        }
    }

    class Samsung : Celular
    {
        public Samsung(string modelo) : base("Samsung", modelo) { }

        public override void Ligar()
        {
            Console.WriteLine($"Samsung {Modelo} ligando com aquele som clássico... Tchururu!");
            ConsumirBateria(6);
        }

        public override void MostrarInfo()
        {
            Console.WriteLine($"Marca: {Marca} | Modelo: {Modelo} | Sistema: Android 12 | Tela AMOLED");
        }

        public override void TirarFoto()
        {
            Console.WriteLine("Samsung: Foto com modo noturno ativado. Show de bola!");
            ConsumirBateria(4);
        }

        public void AtivarBixby()
        {
            if (Bateria < 10)
            {
                Console.WriteLine("Bixby não quer funcionar com pouca bateria, carregue antes.");
                return;
            }
            Console.WriteLine("Bixby ativada! Pergunte o que quiser.");
            ConsumirBateria(8);
        }
    }

    class Apple : Celular
    {
        public Apple(string modelo) : base("Apple", modelo) { }

        public override void Ligar()
        {
            Console.WriteLine($"Apple {Modelo} liga com aquele som inconfundível. Só Apple tem isso.");
            ConsumirBateria(7);
        }

        public override void MostrarInfo()
        {
            Console.WriteLine($"Marca: {Marca} | Modelo: {Modelo} | Sistema: iOS 15 | Tela Retina");
        }

        public override void TirarFoto()
        {
            Console.WriteLine("Apple: Modo retrato ativado. Clique perfeito!");
            ConsumirBateria(3);
        }

        public void AbrirSiri()
        {
            if (Bateria < 5)
            {
                Console.WriteLine("Siri dormiu, carga tá baixa demais.");
                return;
            }
            Console.WriteLine("Siri ativa! O que posso ajudar?");
            ConsumirBateria(6);
        }
    }

    class Xiaomi : Celular
    {
        public Xiaomi(string modelo) : base("Xiaomi", modelo) { }

        public override void MostrarInfo()
        {
            Console.WriteLine($"Marca: {Marca} | Modelo: {Modelo} | Sistema: MIUI 12 | Tela IPS LCD");
        }

        public override void TirarFoto()
        {
            Console.WriteLine("Xiaomi: Foto tirada, sem frescura.");
            ConsumirBateria(3);
        }

        public void AtivarModoEconomia()
        {
            Console.WriteLine("Modo economia ativado. Bateria vai durar mais, mas fica meio lento.");
        }

        public override void Ligar()
        {
            Console.WriteLine($"Xiaomi {Modelo} ligando... Espera aí que já vai.");
            ConsumirBateria(5);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Celular[] meusCelulares = {
                new Samsung("Galaxy S21 Ultra"),
                new Apple("iPhone 13 Pro"),
                new Xiaomi("Redmi Note 11")
            };

            foreach (var cel in meusCelulares)
            {
                cel.Ligar();
                cel.MostrarInfo();
                cel.TirarFoto();
                cel.MostrarBateria();

                if (cel is Samsung s)
                {
                    s.AtivarBixby();
                    s.MostrarBateria();
                }
                else if (cel is Apple a)
                {
                    a.AbrirSiri();
                    a.MostrarBateria();
                }
                else if (cel is Xiaomi x)
                {
                    x.AtivarModoEconomia();
                }

                cel.MandarMensagem("99999-9999", "E aí, beleza?");
                cel.FazerLigacao("88888-8888");

                cel.MostrarBateria();

                if (cel.Bateria < 20)
                {
                    Console.WriteLine("Bateria baixa, bora carregar.");
                    cel.Recarregar();
                    cel.MostrarBateria();
                }

                cel.Desligar();

                Console.WriteLine("\n-------------------------\n");
            }

            Console.WriteLine("Programa finalizado, valeu!");
        }
    }
}
