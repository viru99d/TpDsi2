using System;
using System.Collections.Generic;

namespace Tp2
{
    class GestorCotizacion
    {
        static List<Cotizacion> Cotizacion = new List<Cotizacion>();

        static void Main(string[] args)
        {
            while (true)
            {
                var finalizado = ProcesoCotizacion();

                if (finalizado) break;
            }

            System.Console.WriteLine("\nGracias por visitarnos");
        }

        static public bool ProcesoCotizacion()
        {
            
            while (true)
            {
                Console.WriteLine("¿Que desea hacer? \n1- Registrarse como cliente \n2- Realizar una cotización");

                var opcionElegidaInicio = Console.ReadLine();
                Console.Clear();
                while(int.TryParse(opcionElegidaInicio, out _) == false)
                {
                    Console.WriteLine("VALOR INGRESADO INCORRECTO, Ingrese un valor entre 1 y 2");
                }
                if(int.Parse(opcionElegidaInicio) == 1) RegistroClientes.RegistrarCliente();

                if (int.Parse(opcionElegidaInicio) == 2)
                {
                    if (RegistroClientes.Clientes.Count == 0)
                    {
                        Console.WriteLine("\nNo hay clientes registrados, por favor registrese");
                        RegistroClientes.RegistrarCliente();
                    }
                }

                Console.Clear();
                Console.WriteLine("\nEn la base de datos, hay cargados " + RegistroClientes.Clientes.Count + " cliente\n");
                RegistroClientes.MostrarCliente();
                Console.WriteLine("\nSeleccione un cliente:");

                var opcionElegidaCliente = Console.ReadLine();
                while (int.TryParse(opcionElegidaCliente, out _) == false)
                {
                    Console.WriteLine("VALOR INGRESADO INCORRECTO, Ingrese un valor mayor a 1 y menor a " + RegistroClientes.Clientes.Count);

                }
                var cliente = RegistroClientes.Clientes[int.Parse(opcionElegidaCliente) - 1];

                Console.Clear();
                Console.WriteLine("\nIndique los metros cuadrados que desea cubrir");
                var opcionMetrosCuadrados = Console.ReadLine();
                decimal metrosCuadrados;
                while (decimal.TryParse(opcionMetrosCuadrados, out metrosCuadrados) == false)
                {
                    Console.WriteLine("\nIngrese un número");
                }

                RegistroMateriales.MostrarMateriales();
                var opcionElegidaMaterial = Console.ReadLine();
                
                while (int.TryParse(opcionElegidaMaterial, out _) == false)
                {
                    Console.WriteLine("VALOR INGRESADO INCORRECTO, Ingrese un valor mayor a 1 y menor a " + RegistroMateriales.Materiales.Count);
                }
                var material = RegistroMateriales.Materiales[int.Parse(opcionElegidaMaterial) - 1];

                RegistroEspesor.MostrarEspesores();
                var opcionElegidaEspesor = Console.ReadLine();
          
                while (int.TryParse(opcionElegidaEspesor, out _) == false)
                {
                    Console.WriteLine("VALOR INGRESADO INCORRECTO, Ingrese un valor mayor a 1 y menor a " + RegistroEspesor.Espesores.Count);
                }
                var espesor = RegistroEspesor.Espesores[int.Parse(opcionElegidaEspesor) - 1];

                Cotizacion cotizacion = new Cotizacion(metrosCuadrados, material, cliente, espesor, DateTime.Now);
                cotizacion.MostrarCotizacion();

                Console.WriteLine("\nDesea seguir navegando?   \n1- Sí \n2- No");
                var opcionElegidaSeguir = int.Parse(Console.ReadLine());
                Console.Clear();
                if (opcionElegidaSeguir == 1) return false;

                else return true;

            }
        }
    }

    class Material
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public Material(string nombre, decimal precio)
        {
            Nombre = nombre;
            Precio = precio;
        }
    }

    class RegistroMateriales
    {
        public static List<Material> Materiales = new List<Material>();

        static RegistroMateriales()
        {
            Materiales.Add(new Material("Grafito", 1500));
            Materiales.Add(new Material("Madera", 3000));
            Materiales.Add(new Material("Metal", 4000));
            Materiales.Add(new Material("Platino", 5000));
            Materiales.Add(new Material("Oro", 7500));

        }

        static public void MostrarMateriales()
        {
            Console.WriteLine("\nLISTA DE MATERIALES:");
            
            int pos = 1;
            foreach(var material in Materiales)
            {
                Console.WriteLine(pos + "-" + material.Nombre + " $"+ material.Precio);
                pos++;
            }
            Console.WriteLine("\nSeleccione un material:");
        }
    }

    class Cliente
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Empresa { get; set; }
        public string DomicilioObra { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }

        public Cliente(string nombre, string apellido, string empresa, string domicilioObra, string email, string telefono)
        {
            Nombre = nombre;
            Apellido = apellido;
            Empresa = empresa;
            DomicilioObra = domicilioObra;
            Email = email;
            Telefono = telefono;
        }

    }

    class RegistroClientes
    {
        public static List<Cliente> Clientes = new List<Cliente>();
        
        static public void RegistrarCliente()
        {
            Console.WriteLine("\nREGISTRO DE CLIENTES");
            Console.WriteLine("\nIngrese su nombre:");
            string nombre = Console.ReadLine();
            Console.WriteLine("\nIngrese su apellido:");
            string apellido = Console.ReadLine();
            Console.WriteLine("\nIngrese el nombre de la empresa:");
            string empresa = Console.ReadLine();
            Console.WriteLine("\nIngrese el domicilio:");
            string domicilio = Console.ReadLine();
            Console.WriteLine("\nIngrese su email:");
            string email = Console.ReadLine();
            Console.WriteLine("\nIngrese el telefono:");
            string telefono = Console.ReadLine();

            Cliente cliente = new Cliente(nombre, apellido, empresa, domicilio, email, telefono);
            RegistroClientes.Clientes.Add(cliente);
        }

        static public void MostrarCliente()
        {
            int i = 1;
            foreach (var clientes in RegistroClientes.Clientes)
            {
                Console.WriteLine("Cliente N°: " +i);
                Console.WriteLine("-Nombre: "+clientes.Nombre + " Apellido: " +clientes.Apellido);
                Console.WriteLine("-Empresa: " + clientes.Empresa);
                Console.WriteLine("-Direccion: " + clientes.DomicilioObra);
                Console.WriteLine("-Email: " + clientes.Email);
                Console.WriteLine("-Teléfono: " + clientes.Telefono);
                Console.WriteLine("_________________________________________");
                Console.WriteLine("");

                i++;
            }
        }

    }

    class Espesor
    {
        public string Tipo;
        public decimal Precio;
        public decimal RendimientoBolsa;

        public Espesor(string tipo, decimal precio, decimal rendimientoBolsa)
        {
            Tipo = tipo;
            Precio = precio;
            RendimientoBolsa = rendimientoBolsa;
            
        }
    }

    class RegistroEspesor
    {
        public static List<Espesor> Espesores = new List<Espesor>();

        static RegistroEspesor()
        {
            Espesores.Add(new Espesor("50mm", 53.60m, 9));
            Espesores.Add(new Espesor("70mm", 87.00m, 7.65m));
            Espesores.Add(new Espesor("100mm", 117.49m, 4.5m));
            Espesores.Add(new Espesor("120mm", 128.48m, 3.6m));
            Espesores.Add(new Espesor("160mm", 143.05m, 2.7m));
            Espesores.Add(new Espesor("200mm", 180.79m, 2.25m));
        }

        static public void MostrarEspesores()
        {
            Console.WriteLine("\nLISTADO DE ESPESORES:");

            int pos = 1;
            foreach (var espesor in Espesores)
            {
                Console.WriteLine(pos + "-" + espesor.Tipo);
                pos++;
            }
            Console.WriteLine("\nSeleccione un espesor:");
        }
    }

    class Cotizacion
    {
        public decimal TotalCotizacion { get; set; }
        public decimal MetrosCuadrados { get; set; }
        public Material Material { get; set; }
        public Cliente Cliente { get; set; }
        public Espesor Espesor { get; set; }
        public DateTime Fecha { get; set; }

        public Cotizacion(decimal metrosCuadrados, Material material, Cliente cliente, Espesor espesor, DateTime fecha)
        {
            MetrosCuadrados = metrosCuadrados;
            Material = material;
            Cliente = cliente;
            Espesor = espesor;
            Fecha = fecha;

        }

        public void MostrarCotizacion()
        {
            
            decimal PrecioBolsa = (Espesor.Precio * Material.Precio * Espesor.RendimientoBolsa);
            decimal CantidadBolsas = Math.Ceiling((MetrosCuadrados / Espesor.RendimientoBolsa));
            decimal TotalCotizacion = CantidadBolsas * PrecioBolsa;
           
            Console.Clear();

            Console.WriteLine("\nDATOS DEL PRESUPUESTO: \n");
            Console.WriteLine("-Fecha de emisión del presupuesto: " + (Fecha = DateTime.Now));
            Console.WriteLine("-Fecha de vencimiento del presupuesto: " + (Fecha.AddDays(30)));
            Console.WriteLine("Total cotizacion: $" + TotalCotizacion);


            Console.WriteLine("\nDATOS DEL CLIENTE:\n");
            Console.WriteLine("-Nombre: " + Cliente.Nombre + " Apellido: " + Cliente.Apellido);
            Console.WriteLine("-Empresa: " + Cliente.Empresa);
            Console.WriteLine("-Direccion: " + Cliente.DomicilioObra);
            Console.WriteLine("-Email: " + Cliente.Email);
            Console.WriteLine("-Teléfono: " + Cliente.Telefono);
            Console.WriteLine("");

            System.Console.WriteLine("\n¿Desea conocer los detalles de su presupuesto? \n-1 Si \n-2 No");
            while (true)
            {
                var opcionDetalles = System.Console.ReadLine();
                if (int.TryParse(opcionDetalles, out var value))
                {
                    if (value >= 1 && value <= 2)
                    {
                        if (value == 1)
                        {
                            System.Console.WriteLine("-Rendimiento por bolsa: " + Espesor.RendimientoBolsa + " metros");
                            System.Console.WriteLine("-Metros cuadrados a cubrir: " + MetrosCuadrados);
                            System.Console.WriteLine("-Material elegido: " + Material.Nombre);
                            System.Console.WriteLine("-Espesor elegido: " + Espesor.Tipo);
                            System.Console.WriteLine("-Cantidad de bolsas necesarias: " + CantidadBolsas);
                            System.Console.WriteLine("-Precio por bolsa: $" + PrecioBolsa);
                            Console.WriteLine("Total cotizacion: $" + TotalCotizacion);
                            break;
                        }
                        else break;
                    }
                    else System.Console.WriteLine("\nVALOR INGRESADO INCORRECTO, ingrese 1 o 2");
                }
            }
        }
    }                
}

    