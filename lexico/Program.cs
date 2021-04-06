using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lexico
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(args[0]);

            char[] simbolos = { '+', '-', '*', '/', '^', '<', '>', '!', '=', '(', ')', '{', '}', ',', ';', ' ' };
            string[] reservadas = { "program", "if", "else", "fi", "do", "until", "while", "read", "write", "float", "int", "bool", "not", "and", "or" };
            List<string> tokens = new List<string>(0);
            string auxiliar = "";
            int fila = 0;
            //int columna = 0; 
            int caso = 0;
            int casoDos = 0;
            try
            {
                System.IO.StreamReader lector = new System.IO.StreamReader("algo.txt");

                string linea;
                int indice = 0;
                while ((linea = lector.ReadLine()) != null)
                {
                    fila++;
                    indice = 0;

                 

                    while (indice < linea.Length)
                    {
                        char caracter = linea[indice];
                       
                        switch (caso)
                        {
                            case 0:

                                switch (caracter)
                                {
                                    case '+': 
                                        tokens.Add(caracter.ToString());
                                        Console.Write("Caracter encontrado: +\n");
                                        break;
                                    case '-':
                                        tokens.Add(caracter.ToString());
                                        Console.Write("Caracter encontrado: -\n");
                                        break;
                                    case '*':
                                        tokens.Add(caracter.ToString());
                                        Console.Write("Caracter encontrado: *\n");
                                        break;
                                    case '/':
                                        if(indice + 1 != linea.Length) { 

                                        
                                            if(linea[indice + 1] == '*' )                                        
                                            {                                           
                                                caso = 1;                                            
                                                casoDos = 1;
                                                Console.WriteLine("Comienzo del comentario en la linea " + fila + " en la columna " + indice);
                                                indice++;
                                        } else if (linea[indice + 1] == '/')
                                        {
                                            caso = 1;
                                            casoDos = 2;
                                                Console.WriteLine("Comienzo del comentario en la linea " + fila + " en la columna " + indice);
                                                indice++;       
                                        } else
                                            {
                                             tokens.Add(caracter.ToString());
                                             Console.Write("Caracter encontrado: /\n");
                                                
                                            }
                                        }
                                        else
                                        {
                                            tokens.Add(caracter.ToString());
                                            Console.Write("Caracter encontrado: /\n");
                                        }
                                        break;
                                    case '^':
                                        tokens.Add(caracter.ToString());
                                        Console.Write("Caracter encontrado: ^\n");
                                        break;
                                    case '<':
                                        if (indice + 1 != linea.Length) { 
                                            if (linea[indice + 1] == '=')
                                        {
                                            indice++;
                                            tokens.Add("<=");
                                            Console.Write("Caracter encontrado: <=\n");
                                        }
                                        else
                                        {
                                            tokens.Add(caracter.ToString());
                                            Console.Write("Caracter encontrado: <\n");
                                        }
                                        }
                                        else { 
                                        tokens.Add(caracter.ToString());
                                        Console.Write("Caracter encontrado: <\n");
                                        }
                                        break;
                                    case '>':
                                        if (indice + 1 != linea.Length) 
                                        { 
                                            if (linea[indice + 1] == '=')                                        
                                            {                                            
                                                indice++;                                            
                                                tokens.Add(">=");
                                                Console.Write("Caracter encontrado: >=\n");
                                            }
                                        else
                                        
                                            {                                            
                                                tokens.Add(caracter.ToString());
                                                Console.Write("Caracter encontrado: >\n");
                                            }
                                        }else
                                            {
                                                tokens.Add(caracter.ToString());
                                                Console.Write("Caracter encontrado: >\n");
                                            }
                                        break;
                                    case '=':
                                        if (indice + 1 != linea.Length) { 
                                            if (linea[indice + 1] == '=')
                                        {
                                            indice++;
                                            tokens.Add("==");
                                            Console.Write("Caracter encontrado: ==\n");
                                        }
                                        else
                                        {
                                            tokens.Add(caracter.ToString());
                                            Console.Write("Caracter encontrado: =\n");
                                        }
                                        }
                                        else
                                        {
                                            tokens.Add(caracter.ToString());
                                            Console.Write("Caracter encontrado: =\n");
                                        }
                                        break;
                                    case '!':
                                        if (indice + 1 != linea.Length)
                                        {
                                        if (linea[indice + 1] == '=')
                                        {
                                            indice++;
                                            tokens.Add("!=");
                                            Console.Write("Caracter encontrado: !=\n");
                                        }
                                        else
                                        {
                                            tokens.Add(caracter.ToString());
                                            Console.Write("Caracter encontrado: !\n");
                                        }
                                        }
                                        else
                                        {
                                            tokens.Add(caracter.ToString());
                                            Console.Write("Caracter encontrado: !\n");
                                        }

                                        break;
                                    case ',':
                                        tokens.Add(caracter.ToString());
                                        Console.Write("Caracter encontrado: ,\n");
                                        break;
                                    case ';':
                                        tokens.Add(caracter.ToString());
                                        Console.Write("Caracter encontrado: ;\n");
                                        break;
                                    case '(':
                                        tokens.Add(caracter.ToString());
                                        Console.Write("Caracter encontrado: (\n");
                                        break;
                                    case ')':
                                        tokens.Add(caracter.ToString());
                                        Console.Write("Caracter encontrado: )\n");
                                        break;
                                    case '{':
                                        tokens.Add(caracter.ToString());
                                        Console.Write("Caracter encontrado: {\n");
                                        break;
                                    case '}':
                                        tokens.Add(caracter.ToString());
                                        Console.Write("Caracter encontrado: }\n");
                                        break;
                                    default:
                                        if (Char.IsLetter(caracter))
                                        {
                                            caso = 2;
                                            auxiliar += caracter;
                                            Console.Write("Caracter encontrado: "+caracter+"\n");  
                                        }
                                        else if (Char.IsDigit(caracter))   
                                        {
                                            caso = 3;
                                            casoDos = 0;
                                            auxiliar += caracter;
                                            Console.Write("Caracter encontrado: " + caracter + "\n");
                                        }
                                        break;
                                } 
                                break; //fin del caso 0 primera entrada
                            case 1: // inicio de reconocimiento de comentarios

                                switch (casoDos)
                                {
                                    case 1:

                                        if (caracter == '*')
                                            casoDos = 3;
                                        break;
                                    case 2:
                                        indice = linea.Length;
                                        caso = 0;
                                        casoDos = 0;
                                        Console.WriteLine("fin del comentario en la linea " + fila + " en la columna " + indice);
                                        break;
                                    case 3:
                                        if (caracter == '/')
                                        {
                                            caso = 0;
                                            casoDos = 0;
                                            Console.WriteLine("fin del comentario en la linea " + fila + " en la columna " + indice);
                                        }
                                        else if (caracter != '*')
                                            casoDos = 1;
                                        break;
                                }

                                break; //fin del caso 1 reconociendo comentarios.


                            case 2:  // inicio de reconocimiento identificadores o reservadas.

                                switch (casoDos)
                                {
                                    case 0:
                                        if(Char.IsLetter(caracter) || Char.IsDigit(caracter))
                                        {
                                            auxiliar += caracter;

                                            if(linea.Length == indice + 1)
                                            {
                                                caso = 0;
                                                casoDos = 0;
                                                Console.WriteLine("expresion encontrada: " + auxiliar);
                                                if (compararReservadas(auxiliar, reservadas))
                                                {
                                                    Console.WriteLine("Es una palabra reservada");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Es un identificador");
                                                }
                                                tokens.Add(auxiliar);
                                                auxiliar = "";
                                            }


                                        }else if (compararSimbolos(simbolos, caracter) )
                                        {
                                            caso = 0;
                                            casoDos = 0;
                                            Console.WriteLine("expresion encontrada: " + auxiliar);
                                            if(compararReservadas(auxiliar,reservadas))
                                            {
                                                Console.WriteLine("Es una palabra reservada");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Es un identificador");
                                            }
                                            tokens.Add(auxiliar);
                                            auxiliar = "";
                                            indice--;
                                        }
                                        else
                                        {
                                            Console.Write("Caracter fuera de rango encontrado: " + caracter + "\n");

                                        }
                                        break;
                                    default:
                                        break;
                                }
                                break; //fin del caso 2 reconociendo identificadores.
                            case 3:
                                switch (casoDos)
                                {
                                    case 0:
                                        if (Char.IsDigit(caracter))
                                        {
                                            auxiliar += caracter;
                                            if (indice + 1 == linea.Length)
                                            {
                                                caso = 0;
                                                casoDos = 0;
                                                Console.WriteLine("Numero encontrado: " + auxiliar);
                                                tokens.Add(auxiliar);
                                                auxiliar = "";
                                            }
                                        }
                                        else if (caracter == '.')
                                        {
                                            auxiliar += caracter;
                                            casoDos = 1;
                                            if(indice + 1 == linea.Length)
                                            {
                                                caso = 0;
                                                casoDos = 0;
                                                auxiliar = "";
                                                Console.WriteLine("Error: punto decimal al final");
                                            }
                                        }
                                        else if (compararSimbolos(simbolos, caracter))
                                        {
                                            caso = 0;
                                            casoDos = 0;
                                            Console.WriteLine("Numero encontrado: " + auxiliar);
                                            tokens.Add(auxiliar);
                                            auxiliar = "";
                                            indice--;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Un error encontrado");
                                            caso = 0;
                                            casoDos = 0;
                                            auxiliar = "";
                                        }
                                        break;
                                    case 1:
                                        if (Char.IsDigit(caracter))
                                        {
                                            auxiliar += caracter;
                                            if (indice + 1 == linea.Length)
                                            {
                                                caso = 0;
                                                casoDos = 0;
                                                Console.WriteLine("Numero encontrado: " + auxiliar);
                                                tokens.Add(auxiliar);
                                                auxiliar = "";
                                            }
                                        }
                                        else if (compararSimbolos(simbolos, caracter))
                                        {
                                            caso = 0;
                                            casoDos = 0;
                                            Console.WriteLine("Numero encontrado: " + auxiliar);
                                            tokens.Add(auxiliar);
                                            auxiliar = "";
                                            indice--;
                                        }else
                                        {
                                            Console.WriteLine("Un error encontrado");
                                            caso = 0;
                                            casoDos = 0;
                                            auxiliar = "";
                                        }
                                        break;
                                    default:
                                        break;
                                }
                                break; /// fin de reconocer números
                            
                            default:
                                Console.WriteLine("Sepa porque pasó por aqui xd. El caso quedó fuera de margen");
                                break;
                        } //fin de las maquinas de estado 

                        indice++;
                    }
                    Console.WriteLine("lista de tokens");
                    foreach(string token in tokens )
                    {
                        Console.WriteLine(token);
                    }
                    
                    
           
                       

                    

                }

                lector.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hubo un error con abrir el archivo de texto " );
            }   
            

            Console.ReadLine();

        }

        //Funciones 

        public static Boolean compararSimbolos(char [] lista , char caracter)
        {
            for (int i = 0; i < lista.Length; i++) { 
                char comparativa = lista[i];

                if(caracter == comparativa)
                    return true;
            }

            return false;
        }
        public static Boolean compararReservadas(string captura, string []reservadas)
        {
            foreach(string palabra in reservadas)
            {
                if (captura == palabra)
                    return true;
            }

            return false;
        }

    }

        
}
