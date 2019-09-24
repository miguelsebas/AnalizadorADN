using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioWeb.Services.Servicios
{
    //Este es el servicio que matchea las concurrencias de las cadenas de DNA pasadas por JSON, las convierto
    //a un array y luego las manejo en el servicio un metodo para cada posibilidad. Devuelve un valor Booleano
    public class MutantServices
    {
        public bool IsMutant(ADN ADN)
        {
            string[] chain = ADN.dna;
            int concurrecias = 0;
            int total = 0;

            int concurrenciasHorizontal = 0;
            int concurrenciasVertical = 0;
            int concuDiagPrincipalIzDe = 0;
            int concuDiagSec1zDeAba = 0;
            int concuDiagSec2zDeAba = 0;
            int concuDiagSec1zDeArriba = 0;
            int concuDiagSec2zDeArriba = 0;
            int concuDiagPrinDerIz = 0;
            int concuDiagSec1DerIzAbajo = 0;
            int concuDiagSec2DerIzAbajo = 0;
            int concuDiagSec1DerIzArriba = 0;
            int concuDiagSec2DerIzArriba = 0;

            concurrenciasHorizontal = Horizontal(chain, concurrecias);
            concurrenciasVertical = Vertical(chain, concurrecias);
            concuDiagPrincipalIzDe = DiagonalPrinIzDe(chain, concurrecias);
            concuDiagSec1zDeAba = DiagonalSec1IzDeAbajo(chain, concurrecias);
            concuDiagSec2zDeAba = DiagonalSec2IzDeAbajo(chain, concurrecias);
            concuDiagSec1zDeArriba = DiagonalSec1IzDeArriba(chain, concurrecias);
            concuDiagSec2zDeArriba = DiagonalSec2IzDeArriba(chain, concurrecias);
            concuDiagPrinDerIz = DiagonalPrinDerIz(chain, concurrecias);
            concuDiagSec1DerIzAbajo = DiagonalSec1DerIzAbajo(chain, concurrecias);
            concuDiagSec2DerIzAbajo = DiagonalSec2DerIzAbajo(chain, concurrecias);
            concuDiagSec1DerIzArriba = DiagonalSec1DerIzArriba(chain, concurrecias);
            concuDiagSec2DerIzArriba = DiagonalSec2DerIzArriba(chain, concurrecias);

            total = concurrenciasHorizontal + concurrenciasVertical + concuDiagPrincipalIzDe + concuDiagSec1zDeAba + concuDiagSec2zDeAba +
               concuDiagSec1zDeArriba + concuDiagSec2zDeArriba + concuDiagPrinDerIz + concuDiagSec1DerIzAbajo +
               concuDiagSec2DerIzAbajo + concuDiagSec1DerIzArriba + concuDiagSec2DerIzArriba;

            if (total >= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
                       
            int Horizontal(string[] dna, int concuHorizontal)
            {
                int contador = 0;
                
                for (int fila = 0; fila < dna.Length; fila++)
                {

                    for (int col = 0; col < dna.Length - 1; col++)
                    {
                        var c = dna[fila][col];
                        var comparar = dna[fila][col + 1];
                        if (c == comparar)
                        {
                            contador++;
                        }
                        else
                        {
                            contador = 0;
                        }
                        if (contador == 4)
                        {
                            concurrenciasHorizontal++;
                        }
                    }
                }
                return concurrenciasHorizontal;
            }
            
            int Vertical(string[] dna, int concurrency)
            {
                int contador = 0;

                for (int fila = 0; fila < dna.Length; fila++)
                {
                    for (int col = 0; col < dna.Length - 1; col++)
                    {
                        var c = dna[col][fila];
                        var comparar = dna[col + 1][fila];
                        if (c == comparar)
                        {
                            contador++;
                        }
                        else
                        {
                            contador = 0;
                        }
                        if (contador == 4)
                        {
                            concurrenciasVertical++;
                        }

                    }
                }
                return concurrenciasVertical;
            }
            
            int DiagonalPrinIzDe(string[] dna, int concurrencias)
            {
                int contador = 0;
                for (int fila = 0; fila < dna.Length - 5; fila++)
                {
                    for (int col = 0; col < dna.Length - 1; col++)
                    {
                        var c = dna[col][col];
                        var comparar = dna[col + 1][col + 1];
                        if (c == comparar)
                        {
                            contador++;
                        }
                        else
                        {
                            contador = 0;
                        }
                        if (contador == 3)
                        {
                            concuDiagPrincipalIzDe++;
                        }
                    }
                }
                return concuDiagPrincipalIzDe;

            }
            
            int DiagonalSec1IzDeAbajo(string[] dna, int concurrencias)
            {
                int contador = 0;

                for (int fila = 0; fila < dna.Length - 5; fila++)
                {
                    for (int col = 0; col < dna.Length - 2; col++)
                    {
                        var c = dna[col + 1][col];
                        var comparar = dna[col + 2][col + 1];
                        if (c == comparar)
                        {
                            contador++;
                        }
                        else
                        {
                            contador = 0;
                        }
                        if (contador == 3)
                        {
                            concuDiagSec1zDeAba++;
                        }
                    }
                }
                return concuDiagSec1zDeAba;

            }
            
            int DiagonalSec2IzDeAbajo(string[] dna, int concurrencias)
            {
                int contador = 0;

                for (int fila = 0; fila < dna.Length - 5; fila++)
                {
                    for (int col = 0; col < dna.Length - 3; col++)
                    {
                        var c = dna[col + 2][col];
                        var comparar = dna[col + 3][col + 1];
                        if (c == comparar)
                        {
                            contador++;
                        }
                        else
                        {
                            contador = 0;
                        }
                        if (contador == 3)
                        {
                            concuDiagSec2zDeAba++;
                        }
                    }
                }
                return concuDiagSec2zDeAba;

            }

            int DiagonalSec1IzDeArriba(string[] dna, int concurrencias)
            {
                int contador = 0;

                for (int fila = 0; fila < dna.Length - 5; fila++)
                {
                    for (int col = 0; col < dna.Length - 2; col++)
                    {
                        var c = dna[col][col + 1];
                        var comparar = dna[col + 1][col + 2];
                        if (c == comparar)
                        {
                            contador++;
                        }
                        else
                        {
                            contador = 0;
                        }
                        if (contador == 3)
                        {
                            concuDiagSec1zDeArriba++;
                        }
                    }
                }
                return concuDiagSec1zDeArriba;

            }

            int DiagonalSec2IzDeArriba(string[] dna, int concurrencias)
            {
                int contador = 0;

                for (int fila = 0; fila < dna.Length - 5; fila++)
                {
                    for (int col = 0; col < dna.Length - 3; col++)
                    {
                        var c = dna[col][col + 2];
                        var comparar = dna[col + 1][col + 3];
                        if (c == comparar)
                        {
                            contador++;
                        }
                        else
                        {
                            contador = 0;
                        }
                        if (contador == 3)
                        {
                            concuDiagSec2zDeArriba++;
                        }
                    }
                }
                return concuDiagSec2zDeArriba;

            }

            int DiagonalPrinDerIz(string[] dna, int concurrencias)
            {
                int contador = 0;
                for (int fila = 0; fila < dna.Length - 5; fila++)
                {
                    for (int col = dna.Length - 1; col > 0; col--)
                    {
                        var c = dna[fila][col];
                        var comparar = dna[fila + 1][col - 1];
                        if (c == comparar)
                        {
                            contador++;
                        }
                        else
                        {
                            contador = 0;
                        }
                        if (contador == 3)
                        {
                            concuDiagPrinDerIz++;
                        }
                        fila++;
                    }
                }
                return concuDiagPrinDerIz;
            }

            int DiagonalSec1DerIzAbajo(string[] dna, int concurrencias)
            {
                int contador = 0;
                for (int fila = 0; fila < dna.Length - 5; fila++)
                {
                    for (int col = dna.Length - 1; col > 1; col--)
                    {
                        var c = dna[fila + 1][col];
                        var comparar = dna[fila + 2][col - 1];
                        if (c == comparar)
                        {
                            contador++;
                        }
                        else
                        {
                            contador = 0;
                        }
                        if (contador == 3)
                        {
                            concuDiagSec1DerIzAbajo++;
                        }
                        fila++;
                    }
                }
                return concuDiagSec1DerIzAbajo;
            }

            int DiagonalSec2DerIzAbajo(string[] dna, int concurrencias)
            {
                int contador = 0;
                for (int fila = 0; fila < dna.Length - 5; fila++)
                {
                    for (int col = dna.Length - 1; col > 2; col--)
                    {
                        var c = dna[fila + 2][col];
                        var comparar = dna[fila + 3][col - 1];
                        if (c == comparar)
                        {
                            contador++;
                        }
                        else
                        {
                            contador = 0;
                        }
                        if (contador == 3)
                        {
                            concuDiagSec2DerIzAbajo++;
                        }
                        fila++;
                    }
                }
                return concuDiagSec2DerIzAbajo;
            }

            int DiagonalSec1DerIzArriba(string[] dna, int concurrencias)
            {
                int contador = 0;
                for (int fila = 0; fila < dna.Length - 5; fila++)
                {
                    for (int col = dna.Length - 1; col > 1; col--)
                    {
                        var c = dna[fila][col - 1];
                        var comparar = dna[fila + 1][col - 2];
                        if (c == comparar)
                        {
                            contador++;
                        }
                        else
                        {
                            contador = 0;
                        }
                        if (contador == 3)
                        {
                            concuDiagSec1DerIzArriba++;
                        }
                        fila++;
                    }
                }
                return concuDiagSec1DerIzArriba;
            }

            int DiagonalSec2DerIzArriba(string[] dna, int concurrencias)
            {
                int contador = 0;
                for (int fila = 0; fila < dna.Length - 5; fila++)
                {
                    for (int col = dna.Length - 1; col > 2; col--)
                    {
                        var c = dna[fila][col - 2];
                        var comparar = dna[fila + 1][col - 3];
                        if (c == comparar)
                        {
                            contador++;
                        }
                        else
                        {
                            contador = 0;
                        }
                        if (contador == 3)
                        {
                            concuDiagSec2DerIzArriba++;
                        }
                        fila++;
                    }
                }
                return concuDiagSec2DerIzArriba;
            }
        }
    }
}
