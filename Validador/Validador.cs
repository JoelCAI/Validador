using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validador
{
    public class Validador
    {
        public static void Bienvenida()
        {
            Console.WriteLine("\n Bienvenido al Programa");
        }

        public static void Despedida()
        {

            Console.WriteLine("\n Gracias por usar nuestro Sistema presione cualquier teclar para finalizar");
            Console.ReadKey();
        }

        public static int PedirInt(string mensaje)
        {
            /* la salida de esta funcion estará en la variable int valor */
            string mensError = "\n\n Por favor ingrese el valor solicitado" +
                               "\n Debe ingresar un valor que no sea vacio y que ese valor sea un número. ";

            int valor;

            Console.WriteLine(mensaje);

            if (!int.TryParse(Console.ReadLine(), out valor))
            {
                Console.Clear();
                Console.WriteLine(mensError);
                return PedirInt(mensaje);
            }
            else
                return valor;

        }

        public static string PedirString(string mensaje)
        {
            string valor;
            bool valido = false;
            string mensajeError = "\n El valor no puede ser vacio y tiene que estar dentro del rango solicitado. ";

            do
            {
                Console.WriteLine(mensaje);
                valor = Console.ReadLine();

                if (valor == "")
                {
                    Console.Clear();
                    Console.WriteLine(mensajeError);
                }
                else
                {
                    valido = true;
                }

            } while (!valido);
            return valor;

        }

        public static string ValidarStringSioNo(string mensaje)
        {

            string opcion;

            string mensError = "\n\n Por favor ingrese el valor solicitado";

            Console.WriteLine(mensaje);

            opcion = Console.ReadLine().ToUpper();
            string opcionC = "SI";
            string opcionD = "NO";

            /* validacion = (opcion == opcionA) || (opcion == opcionB);*/

            if (opcion == "" || (opcion != opcionC) & (opcion != opcionD))
            {
                Console.Clear();
                Console.WriteLine(mensError);
                return ValidarStringSioNo(mensaje);
            }
            else
                return opcion;
        }

        public static void ContieneTexto(string subCadena, string cadena)
        {
            string s1 = cadena;
            string s2 = subCadena;
            bool b = s1.Contains(s2);

            if (b)
            {
                Console.Clear();
                Console.WriteLine("\n '{0}' está en la Cadena '{1}': {2}",
                            s2, s1, b);
                int index = s1.IndexOf(s2);
                if (index >= 0)
                    Console.WriteLine("\n '{0}' esta en la posición {1}",
                                  s2, index + 1);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\n '{0}' No está en la Cadena '{1}': {2}",
                            s2, s1, b);
            }

        }

        public static void MostrarString(string cadena)
        {

            Console.WriteLine("\n Usted escribio " + "*" + cadena + "*");

        }

        public static string PedirCaracterString(string mensaje, int min, int max)
        {
            string valor;
            bool valido = false;
            string mensajeMenu = "\n El número de caracteres a ingresar es entre " + min + " y " + max;
            string mensajeError = "\n El valor no puede ser vacio y tiene que estar dentro del rango solicitado. ";

            do
            {

                Console.WriteLine(mensaje);
                Console.WriteLine(mensajeMenu);

                valor = Console.ReadLine();


                if (valor.Length < min || valor.Length > max)
                {
                    Console.Clear();
                    Console.WriteLine(mensajeError);

                }
                else
                {

                    valido = true;

                }

            } while (!valido);


            return valor;

        }

        public static decimal PedirNumeroDecimal(string mensaje)
        {

            decimal valor;

            bool valido = false;

            /*string opcion = mensaje.Replace('.', ',');*/

            string mensajeDos = "\n Si va a ingresar un número decimal ingrese una " + "*,*" + " en vez de " + "*.*"
                                 + " \n Recuerde que de no hacerlo el sistema lo tomará como un número ENTERO";
            string mensajeError = "\n El valor no puede ser vacio y tiene que estar entre el rango del Menu solicitado. ";

            do
            {

                Console.WriteLine(mensaje);
                Console.WriteLine(mensajeDos);

                if (!decimal.TryParse(Console.ReadLine(), out valor))
                {
                    Console.Clear();
                    Console.WriteLine("\n");
                    Console.WriteLine(mensajeError);
                }
                else
                {
                    valido = true;
                }

            } while (!valido);

            return valor;
        }

        public static DateTime ValidarFechaIngresada(string mensaje)
        {
            bool ingresoCorrecto;
            DateTime fechaValida;

            do
            {
                Console.Clear();
                Console.WriteLine("\n Ingrese un formato válido.");
                Console.WriteLine("\n El formato correcto es *dd/mm/aaaa*.");
                Console.WriteLine("\n También puede ser *dd/mm/aaaa hh:mm:ss*.");
                Console.WriteLine(mensaje);
                string ingresoNacimiento = Console.ReadLine();

                ingresoCorrecto = DateTime.TryParse(ingresoNacimiento, out fechaValida);

                if (!ingresoCorrecto)
                {
                    continue;
                }

            } while (!ingresoCorrecto);

            return fechaValida;
        }

        /* ARRAY FECHAS */
        public static void RegistrarFecha(ref DateTime[] arregloFecha)
        {
            for (int i = 0; i < arregloFecha.Length; i++)
            {
                DateTime fecha;

                /*Este Do while verifica que el dato número "x" no se vuelva a ingresar dos veces
                  porque la funcion BuscarNumero verifica que ya hay una posicion para "x"  */
                do
                {

                    fecha = ValidarFechaIngresada("\n Ingrese el número " + (i + 1).ToString() + ": ");

                    Console.Clear();
                    if (!(BuscarFecha(arregloFecha, fecha) == -1))
                    {
                        Console.Clear();
                        Console.WriteLine("El elemento *" + fecha + "* ya existe. Utilice otra forma de nombrarlo");
                    }

                } while (BuscarFecha(arregloFecha, fecha) != -1);
                arregloFecha[i] = fecha;

            }

        }

        public static int BuscarFecha(DateTime[] arregloFecha, DateTime fecha)
        {
            int posicion = -1;
            for (int i = 0; i < arregloFecha.Length; i++)
            {
                /*Si el nombre ingresado por el usuario coincide con alguno del arreglo se retorna la posicion valida*/
                if (arregloFecha[i] == fecha)
                {
                    posicion = i;
                }


            }
            return posicion;
        }

        public static void MostrarListadoFecha(DateTime[] arregloFecha)
        {
            /*Console.Clear();*/
            Console.WriteLine("\n Listado de elementos en el Arreglo");
            for (int i = 0; i < arregloFecha.Length; i++)
            {
                Console.WriteLine(" " + arregloFecha[i].ToLongDateString());
            }
        }


        /* ARREGLO INT */
        public static void RegistrarNumero(ref int[] arregloNumero)
        {
            for (int i = 0; i < arregloNumero.Length; i++)
            {
                int numero;
                /*Este Do while verifica que el dato número "x" no se vuelva a ingresar dos veces
                  porque la funcion BuscarNumero verifica que ya hay una posicion para "x"  */
                    do
                    {
                       numero = PedirInt("\n Ingrese el número " + (i + 1).ToString() + ": ");
                       Console.Clear();
                       if (!(BuscarNumero(arregloNumero, numero) == -1))
                       {
                           Console.Clear();
                           Console.WriteLine("El elemento *" + numero + "* ya existe. Utilice otra forma de nombrarlo");
                       }
                    } while (BuscarNumero(arregloNumero, numero) != -1);
                   arregloNumero[i] = numero;
             }
        }


        public static int BuscarNumero(int[] arregloNumeros, int numero)
        {
            int posicion = -1;
            for (int i = 0; i < arregloNumeros.Length; i++)
            {
                /*Si el nombre ingresado por el usuario coincide con alguno del arreglo se retorna la posicion valida*/
                if (arregloNumeros[i] == numero)
                {
                    posicion = i;
                }
            }
            return posicion;
        }

        public static void MostrarListado(int[] arregloNumero)
        {
            /*Console.Clear();*/
            Console.WriteLine("\n Listado de elementos en el Arreglo");
            for (int i = 0; i < arregloNumero.Length; i++)
            {
                Console.Write(" " + arregloNumero[i]);
            }
        }


        /* COMPARAR DOS NUMEROS ENTEROS */
        public static int PedirIntComparar(string mensaje, int numeroAnterior)
        {
            /* la salida de esta funcion estará en la variable int valor */
            string mensError = "\n\n Por favor ingrese el valor solicitado" +
                               "\n Debe ingresar un valor que no sea vacio y que ese valor sea mayor al número anterior " +
                               "ingresado. ";


            int valor;
            string cadena;
            Console.WriteLine(mensaje);
            Console.WriteLine(" El número anterior que ingreso es: " + numeroAnterior);
            cadena = Console.ReadLine();

            if (!int.TryParse(cadena, out valor))
            {
                Console.Clear();
                Console.WriteLine(mensError);
                return PedirIntComparar(mensaje, numeroAnterior);
            }

            int numero;
            bool ok = int.TryParse(cadena, out numero);
            if (numeroAnterior >= numero)
            {
                Console.Clear();
                Console.WriteLine(mensError);
                return PedirIntComparar(mensaje, numeroAnterior);
            }
            else
                return valor;
        }

        public static void CompararStringConNumeroInt(string str1)
        {
            string opcion = str1.Replace('.', ',');

            int nuevoUno;

            bool ok = int.TryParse(opcion, out nuevoUno);

            decimal numeroDos;

            bool okDos = decimal.TryParse(opcion, out numeroDos);


            if (ok)
            {
                Console.WriteLine("\n La cadena" + " *" + str1 + "*" + " Es un número Entero y es: " + "*" + nuevoUno + "*");

            }
            else if (okDos)
            {
                Console.WriteLine("\n La cadena" + " *" + str1 + "*" + " Es un número decimal " + "*" + numeroDos + "*"
                                  + " pero no un número entero");
            }

            else
            {

                Console.WriteLine("\n La cadena" + " *" + str1 + "*" + " NO es un número ");
                Console.WriteLine("\n Recuerde ingresar un valor numérico si desea que el Sistema lo tome en cuenta");

            }
        }

        public static void CompararIgualdadStringSinImportarMayusculaMinuscula(string str1, string str2)
        {
            string nuevoUno = str1.ToUpper();
            string nuevoDos = str2.ToUpper();

            bool comparacion = nuevoUno.Equals(nuevoDos);

            if (comparacion == true)
            {
                Console.WriteLine("\n La cadena" + " *" + str1 + "*" + " SI tiene el mismo valor que la cadena " + "*" + str2 + "*");
            }
            else
            {

                Console.WriteLine("\n La cadena" + " *" + str1 + "*" + " NO tiene el mismo valor que la cadena " + "*" + str2 + "*");
            }
        }

        public static void CompararIgualdadString(string str1, string str2)
        {

            bool comparacion = str1.Equals(str2);

            if (comparacion == true)
            {
                Console.WriteLine("\n La cadena" + " *" + str1 + "*" + " SI tiene el mismo valor que la cadena " + "*" + str2 + "*");
            }
            else
            {

                Console.WriteLine("\n La cadena" + " *" + str1 + "*" + " NO tiene el mismo valor que la cadena " + "*" + str2 + "*");
            }
        }


        public static void VocalTildada(string cadena)
        {

            string opcion = cadena.Replace('á', 'a').Replace('é', 'e').Replace('í', 'i').Replace('ó', 'o').Replace('ú', 'u');

            Console.WriteLine("\n Usted escribio " + "*" + cadena + "*" + "\n\n Ahora su frase es: " + "*" + opcion + "*");

        }

        public static void TeclaControlG()
        {
            Console.Clear();
            ConsoleKeyInfo input;
            do
            {
                Console.WriteLine(" Presione Control + G al mismo tiempo si desea salir.");

                input = Console.ReadKey(true);

                Console.Clear();
                StringBuilder output = new StringBuilder(
                              String.Format("Usted Presionó {0}", input.Key.ToString()));
                bool modifiers = false;

                if ((input.Modifiers & ConsoleModifiers.Alt) == ConsoleModifiers.Alt)
                {
                    Console.Clear();
                    output.Append(" + " + ConsoleModifiers.Alt.ToString());
                    modifiers = true;
                }
                if ((input.Modifiers & ConsoleModifiers.Control) == ConsoleModifiers.Control)
                {
                    if (modifiers)
                    {
                        Console.Clear();
                        output.Append(" y ");
                    }
                    else
                    {
                        Console.Clear();
                        output.Append(" +");
                        modifiers = true;
                    }
                    output.Append(ConsoleModifiers.Control.ToString());
                }
                if ((input.Modifiers & ConsoleModifiers.Shift) == ConsoleModifiers.Shift)
                {
                    if (modifiers)
                    {
                        Console.Clear();
                        output.Append(" y ");
                    }
                    else
                    {
                        Console.Clear();
                        output.Append(" + ");
                        modifiers = true;
                    }
                    output.Append(ConsoleModifiers.Shift.ToString());
                }
                output.Append(".");
                Console.WriteLine(output.ToString());
                Console.WriteLine();
            } while (input.Key != ConsoleKey.G || (input.Modifiers & ConsoleModifiers.Control) != ConsoleModifiers.Control);

            if (input.Key == ConsoleKey.G && ((input.Modifiers & ConsoleModifiers.Control) == ConsoleModifiers.Control))
            {
                Validador.Despedida();
            }
        }

        public static void TeclaControlShiftF()
        {
            Console.Clear();
            ConsoleKeyInfo input;
            do
            {
                Console.WriteLine(" Presione Control + Shift + F al mismo tiempo si desea salir.");

                input = Console.ReadKey(true);

                Console.Clear();
                StringBuilder output = new StringBuilder(
                              String.Format("Usted Presionó {0}", input.Key.ToString()));
                bool modifiers = false;

                if ((input.Modifiers & ConsoleModifiers.Alt) == ConsoleModifiers.Alt)
                {
                    Console.Clear();
                    output.Append(" + " + ConsoleModifiers.Alt.ToString());
                    modifiers = true;
                }
                if ((input.Modifiers & ConsoleModifiers.Control) == ConsoleModifiers.Control)
                {
                    if (modifiers)
                    {
                        Console.Clear();
                        output.Append(" y ");
                    }
                    else
                    {
                        Console.Clear();
                        output.Append(" +");
                        modifiers = true;
                    }
                    output.Append(ConsoleModifiers.Control.ToString());
                }
                if ((input.Modifiers & ConsoleModifiers.Shift) == ConsoleModifiers.Shift)
                {
                    if (modifiers)
                    {
                        Console.Clear();
                        output.Append(" y ");
                    }
                    else
                    {
                        Console.Clear();
                        output.Append(" + ");
                        modifiers = true;
                    }
                    output.Append(ConsoleModifiers.Shift.ToString());
                }
                output.Append(".");
                Console.WriteLine(output.ToString());
                Console.WriteLine();
            } while (input.Key != ConsoleKey.F || ((input.Modifiers & ConsoleModifiers.Control) != ConsoleModifiers.Control)
                    || ((input.Modifiers & ConsoleModifiers.Shift) != ConsoleModifiers.Shift));

            if (input.Key == ConsoleKey.F || ((input.Modifiers & ConsoleModifiers.Control) == ConsoleModifiers.Control)
                    || ((input.Modifiers & ConsoleModifiers.Shift) == ConsoleModifiers.Shift))
            {
                Validador.Despedida();
            }
        }

        public static void Tecla(string mensaje)
        {
            string opcion = mensaje;
            ConsoleKeyInfo cki;
            Console.TreatControlCAsInput = true;

            Console.Clear();

            do
            {

                Console.WriteLine("\nPresione cualquier variación de CTRL o ALT o SHIFT + tecla de Consola.");
                Console.WriteLine(opcion);

                cki = Console.ReadKey();
                Console.Clear();
                Console.WriteLine("\nUsted Presiono: ");
                if ((cki.Modifiers & ConsoleModifiers.Alt) != 0) Console.Write("ALT+");
                if ((cki.Modifiers & ConsoleModifiers.Shift) != 0) Console.Write("SHIFT+");
                if ((cki.Modifiers & ConsoleModifiers.Control) != 0) Console.Write("CTL+");
                Console.WriteLine(cki.Key.ToString());


            } while (cki.Key != ConsoleKey.X);

            if (cki.Key == ConsoleKey.End)
            {
                Console.Clear();
                Console.WriteLine("Usted presionó la tecla " + "*" + "End" + "*" + " para salir. Hasta Luego");
            }
        }



    }
}
