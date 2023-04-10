using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemasLineares
{
    public partial class frmSistemasLineares : Form
    {


        /// <summary>
        /// O primeiro metodo a iniciar dentro da tela. 
        /// </summary>
        public frmSistemasLineares()
        {
            InitializeComponent();

            NumVariaveisFrm(gridTabela, 2);

        }
        
        
        /// <summary>
        /// Este metodo calcula quantas matrizes tem no arquivo txt upado.
        /// </summary>
        /// <param name="arquivo">Recebe um vetor de string de cada linha do arquivo</param>
        /// <returns>Retorna a quantidade de matriz</returns>
        static int QtnMatrizTXT(string[] arquivo)
        {
            int qntMatriz = 0;
            int qntLinha;

            for (int k = 0; k < arquivo.Length; k += qntLinha)
            {
                qntLinha = 0;
                qntLinha += arquivo[k].Split(';').Length - 1;


                for (int i = k; i < k + qntLinha; i++)
                    if (qntLinha != arquivo[i].Split(';').Length - 1 || k + qntLinha > arquivo.Length)
                    {
                        MessageBox.Show($"Não foi encontrada a matriz da {k + 1}° à {k + qntLinha}° linha. Não ocorrera mais a leitura do arquivo.");
                        return qntMatriz;
                    }


                if (qntLinha == 0)
                {
                    MessageBox.Show($"Não foi encontrada a matriz na {k + 1}° linha. A partir dela, não ocorrera mais a leitura do arquivo.");
                    return qntMatriz;
                }

                qntMatriz += 1;
            }

            return qntMatriz;
        }


        /// <summary>
        /// Este metodo, ao ler o arquivo txt, ele separa as matrizes por indice. Cada matriz esta armazenado em um incide, ex Matriz[0][][].
        /// </summary>
        /// <param name="qntMatriz">Recebe o numero de matriz no arquivo txt</param>
        /// <param name="arquivo">Recebe o arquivo a ser lido</param>
        /// <returns>Retorna a todas as matrize separado por indice, ex Matriz[a][][]</returns>
        static double[][][] SepararMatrizesTXT(int qntMatriz, string[] arquivo)
        {

            double[][][] vetorAllMatriz = new double[qntMatriz][][];

            int indiceMatriz = 0;
            int qntLinha;
            int contadorLinha;

            for (int matriz = 0; matriz < arquivo.Length && indiceMatriz != qntMatriz; matriz += qntLinha)
            {
                qntLinha = 0;
                contadorLinha = 0;
                qntLinha += arquivo[matriz].Split(';').Length - 1;

                vetorAllMatriz[indiceMatriz] = new double[qntLinha][];


                try
                {
                    for (int i = matriz; i < matriz + qntLinha; i++)
                    {
                        vetorAllMatriz[indiceMatriz][contadorLinha] = new double[qntLinha + 1];

                        for (int j = 0; j < (qntLinha + 1); j++)
                            vetorAllMatriz[indiceMatriz][contadorLinha][j] = Convert.ToDouble(arquivo[i].Split(';')[j]);

                        ++contadorLinha;
                    }
                }
                catch
                {
                    MessageBox.Show($"Não foi possivel processar a {indiceMatriz + 1}° matriz. Esta matriz foi desconsiderada.");

                    vetorAllMatriz[indiceMatriz] = null;
                }


                ++indiceMatriz;
            }

            return vetorAllMatriz;
        }
        
        
        /// <summary>
        /// Este metodo reorganiza a matriz para que o primeiro indice[0][0] não seja igual a 0. Alem disso, ele ja define o tamnho da
        /// matriz escalonada.
        /// </summary>
        /// <param name="matriz">Recebe a matriz a ser formatada.</param>
        /// <returns>Retorna a matriz formatada e com o tamanho para escalonar</returns>
        static double[][] FormatadorMatriz(double[][] matriz)
        {
            int totalLinhas = 0;

            int numVariavelInicio = matriz.GetLength(0);


            for (int a = 0; a < numVariavelInicio; a++)
                totalLinhas += numVariavelInicio - a;


            double[][] matrizResultante = new double[totalLinhas][];

            int linha;

            for (int j = 0; j < numVariavelInicio; j++)
            {

                matrizResultante[j] = new double[numVariavelInicio + 1];

                linha = 0;


                for (int i = 0; i < numVariavelInicio; i++)
                    if (Math.Abs(matriz[linha][j]) < Math.Abs(matriz[i][j]))
                        linha = i;


                for (int i = 0; i <= numVariavelInicio; i++)
                {
                    matrizResultante[j][i] = matriz[linha][i];
                    matriz[linha][i] = 0;
                }
            }

            return matrizResultante;
        }


        /// <summary>
        /// Este metodo escalona a matriz.
        /// </summary>
        /// <param name="matriz">Recebe o vetor matriz ja com o tamanho predefinido para escalonar.</param>
        /// <returns></returns>
        static double[][] Escalonar(double[][] matriz)
        {
            int indice = 0;
            int indice_k = -1;
            int numVariavelInicio = matriz[0].Length - 1;

            for (int k = 0; k < matriz.GetLength(0) - 1; k += numVariavelInicio - indice_k)
            {

                for (int i = k; i < k + numVariavelInicio - indice - 1; i++)
                {
                    matriz[i + numVariavelInicio - indice] = new double[numVariavelInicio - indice];

                    for (int j = 0; j < numVariavelInicio - indice; j++)
                        matriz[i + numVariavelInicio - indice][j] = matriz[k][0] * matriz[i + 1][j + 1] - matriz[i + 1][0] * matriz[k][j + 1];

                }

                ++indice;
                ++indice_k;
            }


            return matriz;
        }


        /// <summary>
        /// Este metodo, a partir da matriz escalonada, calcula os Xs do sistema.
        /// </summary>
        /// <param name="matriz">Recebe a matriz ja escalonada para calular</param>
        /// <returns>Retorna os vetores com o resultado dos Xs</returns>
        static double[] CalculadoraXs(double[][] matriz)
        {
            int numVarivaeis = matriz[0].Length - 1;
            int indiceColunas = matriz.GetLength(0) - 1, indiceVariaveis = numVarivaeis - 1;
            int contadorLinha = 1, contadorColuna;
            double totalSubtrair;

            double[] variaveis = new double[numVarivaeis];

            variaveis[indiceVariaveis] = matriz[indiceColunas][1] / matriz[indiceColunas][0];

            for (int i = indiceColunas - 1; i >= numVarivaeis - 1; i -= contadorLinha)
            {
                totalSubtrair = 0;
                contadorColuna = numVarivaeis - 1;

                for (int j = matriz[i].Length - 2; j > 0; --j)
                {
                    totalSubtrair += matriz[i][j] * variaveis[contadorColuna];
                    --contadorColuna;
                }

                --indiceVariaveis;

                variaveis[indiceVariaveis] = (matriz[i][matriz[i].Length - 1] - totalSubtrair) / matriz[i][0];

                ++contadorLinha;
            }

            return variaveis;
        }


        /// <summary>
        /// Este metodo abre a caixa de seleçao e lê o arquivo. 
        /// </summary>
        /// <returns>Retorna o vetor string de todas a linhas lida. Se nao for possivel ler, ele retorna null</returns>
        static string[] LerArquivo()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            string nameArq;

            if (openFileDialog.ShowDialog().ToString() == "OK")
            {
                nameArq = openFileDialog.FileName;

                try
                {
                    if (Path.GetExtension(nameArq) == ".txt")
                        return File.ReadAllLines(nameArq);
                    else
                    {
                        MessageBox.Show("Poxa, o arquivo não é \".txt\"");
                        return null;
                    }
                }
                catch
                {
                    MessageBox.Show("Houve um erro. Esee arquivo não tem as definições para ser lido por este programa.");
                    return null;
                }

            }
            else
                return null;

        }


        /// <summary>
        /// A partir do controle NumericUpDown, ele muda o tamanho do grid
        /// </summary>
        /// <param name="dataGrid">Recebe o grid a ser alterado</param>
        /// <param name="numValor">Recebe o numero de variaveis do NumericUpDown</param>
        public void NumVariaveisFrm(DataGridView dataGrid, int numValor)
        {
            gridTabela.Columns.Clear();
            gridTabela.Rows.Clear();

            for (int i = 0; i < numValor; i++)
            {
                dataGrid.Columns.Add("x" + (i + 1).ToString(), "X" + (i + 1).ToString());
                dataGrid.Columns["x" + (i + 1).ToString()].Width = 50;
                dataGrid.Rows.Add();
            }

            dataGrid.Columns.Add("R", "R");
            dataGrid.Columns["R"].Width = 60;

            dataGrid.AllowUserToAddRows = false;

        }


        /// <summary>
        /// Este metodo rebe o vetor matriz e transforma em TextBox matriz aumentada.
        /// </summary>
        /// <param name="matriz">Recebe o vetor matriz</param>
        /// <returns>Retorna a matriz em TextBox</returns>
        public TextBox MatrizAumentadaTxtBox(double[][] matriz)
        {
            TextBox txtBox = new TextBox();

            txtBox.Text = "Matriz aumentada(e reorganizada):" + Environment.NewLine;

            for (int i = 0; i < matriz[0].Length - 1; i++)
                txtBox.Text += $"X{i + 1}".PadLeft(20, ' ');

            txtBox.Text += "R".PadLeft(20, ' ') + Environment.NewLine;

            for (int i = 0; i < matriz[0].Length - 1; i++)
            {
                for (int j = 0; j < matriz[0].Length; j++)
                    if (matriz[i][j].ToString().Length > 10)
                        txtBox.Text += matriz[i][j].ToString("0.000e+0").PadLeft(20, ' ');
                    else
                        txtBox.Text += matriz[i][j].ToString("0.000").PadLeft(20, ' ');


                txtBox.Text += Environment.NewLine;
            }

            return txtBox;
        }


        /// <summary>
        /// Este metodo adiciona zero a esquerda da matriz escalonada para ser usado em MatrizParaXsTxtBox().
        /// </summary>
        /// <param name="matrizEscalonada">Recebe a matriz escalonada</param>
        /// <returns>Retorna a matriz escalonada com os zeros preenchidos as esquerda</returns>
        static double[][] FormatarAddZero(double[][] matrizEscalonada)
        {
            int tamanhoLinha = matrizEscalonada.GetLength(0);
            int tamanhoColuna = matrizEscalonada[0].Length;

            double[][] matrizFormatada = new double[tamanhoLinha][];

            for (int i = 0; i < tamanhoLinha; i++)
            {
                matrizFormatada[i] = new double[tamanhoColuna];

                int j_k2 = matrizFormatada[i].Length - matrizEscalonada[i].Length;

                for (int j = 0; j < matrizEscalonada[i].Length; j++)
                {
                    matrizFormatada[i][j_k2] = matrizEscalonada[i][j];
                    ++j_k2;
                }

            }
            return matrizFormatada;
        }


        /// <summary>
        /// Este metodo calcula a matriz e retorna os valores de Xs em TextBox.
        /// </summary>
        /// <param name="matriz">Recebe a matriz escalona</param>
        /// <returns>Retorna, em TextBox, os resultados de Xs </returns>
        public TextBox MatrizParaXsTxtBox(double[][] matriz)
        {
            TextBox txtBox = new TextBox();

            int numVariaveis = matriz[0].Length - 1;
            int indiceResto;

            int[] indiceVar = new int[numVariaveis];
            indiceVar[0] = numVariaveis - 1;
            for (int a = 1; a < numVariaveis; a++)
                indiceVar[a] = indiceVar[a - 1] + numVariaveis - a;


            for (int k = 0; k < numVariaveis - 1; k++)
            {
                txtBox.Text += Environment.NewLine + $"Matriz  equivalente para X{k + 1}:" + Environment.NewLine;

                for (int j = 0; j < numVariaveis; j++)
                    txtBox.Text += $"X{j + 1}".PadLeft(20, ' ');

                txtBox.Text += "R".PadLeft(20, ' ') + Environment.NewLine;

                indiceResto = 0;

                for (int i = 0; i < numVariaveis; i++)
                {
                    if (i <= k)
                        for (int j = 0; j < matriz[indiceVar[i]].Length; j++)
                            if (matriz[indiceVar[i]][j].ToString().Length > 10)
                                txtBox.Text += matriz[indiceVar[i]][j].ToString("0.000e+0").PadLeft(20, ' ');
                            else
                                txtBox.Text += matriz[indiceVar[i]][j].ToString("0.000").PadLeft(20, ' ');
                    else
                    {
                        ++indiceResto;

                        for (int j = 0; j < matriz[indiceVar[k] + 1].Length; j++)
                            if (matriz[indiceVar[k] + indiceResto][j].ToString().Length > 10)
                                txtBox.Text += matriz[indiceVar[k] + indiceResto][j].ToString("0.000e+0").PadLeft(20, ' ');
                            else
                                txtBox.Text += matriz[indiceVar[k] + indiceResto][j].ToString("0.000").PadLeft(20, ' ');

                    }

                    txtBox.Text += Environment.NewLine;
                }

            }

            return txtBox;
        }


        /// <summary>
        /// Este metodo faz a prova real do calculo do sistema linear.
        /// </summary>
        /// <param name="matriz">Recebe a matriz escalonada</param>
        /// <returns>Retorna, em TextBox, a matriz montada com a prova real</returns>
        public TextBox ProvaRealMatrizTxtBox(double[][] matriz)
        {
            double[] resultado = CalculadoraXs(matriz);
            TextBox txtBox = new TextBox();
            double soma, point;
            int indiceNumVar = matriz[0].Length - 1;


            txtBox.Text += Environment.NewLine + "*** PROVA REAL ***" + Environment.NewLine;

            for (int i = 0; i < indiceNumVar; i++)
                txtBox.Text += $"X{i + 1}".PadLeft(20, ' ');

            txtBox.Text += "R".PadLeft(25, ' ') + Environment.NewLine;

            for (int i = 0; i < indiceNumVar; i++)
            {
                soma = 0;

                for (int j = 0; j < indiceNumVar; j++)
                {
                    point = (matriz[i][j] * resultado[j]);
                    soma += point;

                    txtBox.Text += point.ToString("0.000e+0").PadLeft(20, ' ');
                }

                if (soma.ToString("0.000e+0") == matriz[i][indiceNumVar].ToString("0.000e+0"))
                    txtBox.Text += (soma.ToString("0.000e+0") + " (OK)").PadLeft(25, ' ');
                else
                    txtBox.Text += (soma.ToString("0.000e+0") + " (NOK)").PadLeft(25, ' ');

                txtBox.Text += Environment.NewLine;
            }


            for (int i = 0; i < indiceNumVar * 10; i++)
                txtBox.Text += "-_";

            txtBox.Text += "-_-_-_-_-_-_-_-_-_-_-_-_-" + Environment.NewLine;

            return txtBox;
        }


        /// <summary>
        /// Este metodo recebe a matriz, calcula e retorna em TextBox os resutados de Xs.
        /// </summary>
        /// <param name="matriz">Recebe a matriz escalonada</param>
        /// <returns>Retorna em TextBox os valores de Xs</returns>
        public TextBox RaizesTxtBox(double[][] matriz)
        {
            TextBox txtBox = new TextBox();

            double[] raizes = CalculadoraXs(matriz);
            txtBox.Text += Environment.NewLine + "*** RAIZES ***" + Environment.NewLine;

            int contador = 1;

            foreach (double valor in raizes)
            {
                if (valor.ToString().Length > 10)
                    txtBox.Text += $"X{contador} = " + valor.ToString("0.000e+0") + Environment.NewLine;
                else
                    txtBox.Text += $"X{contador} = " + valor.ToString("0.000") + Environment.NewLine;

                ++contador;
            }

            return txtBox;
        }


        /// <summary>
        /// Capturar todo o valor do grid e transforma em um vetor matriz
        /// </summary>
        /// <param name="grid">Recebe o grid a ser capturado o valor</param>
        /// <param name="numLinha">Recebe o numero de linhas da matriz a ser montada</param>
        /// <returns>Retorna a matriz em double</returns>
        public double[][] CapturarGrid(DataGridView grid, int numLinha)
        {
            double[][] matriz = new double[numLinha][];

            int i = 0, j = 0;

            try
            {
                for (i = 0; i < numLinha; i++)
                {
                    matriz[i] = new double[numLinha + 1];

                    for (j = 0; j < numLinha + 1; j++)
                        matriz[i][j] = Convert.ToDouble(grid[j, i].Value);
                }
            }
            catch
            {
                MessageBox.Show($"Ops, não foi identificado um números na {i + 1}º linha da {j + 1}° coluna");

                return null;
            }

            return matriz;

        }


        /// <summary>
        /// Evento para capturar quando o usuario altera o valor do NumericUpDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NrVariavel_ValueChanged(object sender, EventArgs e)
        {
            NumVariaveisFrm(gridTabela, Convert.ToInt32(nr_Variavel.Value));
        }


        /// <summary>
        /// Evento para capturar quando usuario clica no bontao calcular
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCalcular(object sender, EventArgs e)
        {
            double[][] matriz = CapturarGrid(gridTabela, Convert.ToInt32(nr_Variavel.Value));

            if (matriz != null)
            {
                txtResultado.Clear();

                double[][] matriz1, matriz2;

                matriz1 = FormatadorMatriz(matriz);

                matriz2 = Escalonar(matriz1);

                txtResultado.Text += MatrizAumentadaTxtBox(matriz2).Text;

                txtResultado.Text += MatrizParaXsTxtBox(FormatarAddZero(matriz2)).Text;

                txtResultado.Text += RaizesTxtBox(matriz2).Text;

                txtResultado.Text += ProvaRealMatrizTxtBox(matriz2).Text + Environment.NewLine + Environment.NewLine;

            }
        }


        /// <summary>
        /// Evento para capturar quando o usuario clica no botao importar e calular.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnArquivo(object sender, EventArgs e)
        {
            string[] arquivo = LerArquivo();

            if (arquivo != null)
            {
                txtResultado.Clear();

                int qntMatriz = QtnMatrizTXT(arquivo);

                double[][][] allMatriz = SepararMatrizesTXT(qntMatriz, arquivo);
                double[][] matriz1, matriz2, matriz3;

                for (int i = 0; i < qntMatriz; i++)
                {
                    matriz1 = allMatriz[i];

                    if (matriz1 != null)
                    {
                        matriz2 = FormatadorMatriz(matriz1);

                        matriz3 = Escalonar(matriz2);

                        txtResultado.Text += MatrizAumentadaTxtBox(matriz3).Text;

                        txtResultado.Text += MatrizParaXsTxtBox(FormatarAddZero(matriz3)).Text;

                        txtResultado.Text += RaizesTxtBox(matriz3).Text;

                        txtResultado.Text += ProvaRealMatrizTxtBox(matriz3).Text + Environment.NewLine + Environment.NewLine;
                    }
                }

            }
        }
    }
}

