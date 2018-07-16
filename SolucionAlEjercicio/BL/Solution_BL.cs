﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
//using static SolucionAlEjercicio.Models.JSONModel;
using static SolucionAlEjercicio.Models.JSONModel;

namespace SolucionAlEjercicio.BL
{
    public class Solution_BL
    {
        private string palabraEncontrada = "";
        private string palabra = "";
        private List<Location> oLocations = new List<Location>();

        private List<Location> FindWord(char[][] oMatrix, int currentRow, int currentCol, char[] oWord, int currentLetter, string sDirection)
        {
            var letra = oWord[currentLetter];
            palabra = String.Join("", oWord);

            if (currentRow >= oMatrix.Length || currentCol >= oMatrix[currentRow].Length) // no hay mas letras en la sopa
                return null;

            if(currentLetter == 0)
            {
                oLocations.Add(new Location(currentRow, currentCol, "N"));

                palabraEncontrada += oWord[currentLetter];
                if (palabra == palabraEncontrada)
                {
                    return oLocations;
                }

                return FindWord(oMatrix, currentRow, currentCol, oWord, currentLetter + 1, "");

            }

            Location res = null;
            if (sDirection == "")
            {
                res = FindN(oMatrix, currentRow, currentCol, oWord, currentLetter);
                if (res != null)
                {
                    oLocations.Add(new Location(res.Row, res.Col, res.NextPosition));

                    palabraEncontrada += oWord[currentLetter];
                    if (palabra == palabraEncontrada)
                    {
                        return oLocations;
                    }

                    return FindWord(oMatrix, res.Row, res.Col, oWord, currentLetter + 1, "");
                }
                sDirection = "NE";
            }

            if (sDirection == "NE" || sDirection == "")
            {
                res = FindNE(oMatrix, currentRow, currentCol, oWord, currentLetter);
                if (res != null)
                {
                    oLocations.Add(new Location(res.Row, res.Col, res.NextPosition));

                    palabraEncontrada += oWord[currentLetter];
                    if (palabra == palabraEncontrada)
                    {
                        return oLocations;
                    }

                    return FindWord(oMatrix, res.Row, res.Col, oWord, currentLetter + 1, "");
                }
                sDirection = "E";
            }

            if (sDirection == "E" || sDirection == "")
            {
                res = FindE(oMatrix, currentRow, currentCol, oWord, currentLetter);
                if (res != null)
                {
                    oLocations.Add(new Location(res.Row, res.Col, res.NextPosition));

                    palabraEncontrada += oWord[currentLetter];
                    if (palabra == palabraEncontrada)
                    {
                        return oLocations;
                    }

                    return FindWord(oMatrix, res.Row, res.Col, oWord, currentLetter + 1, "");
                }
                sDirection = "SE";
            }

            if (sDirection == "SE" || sDirection == "")
            {
                res = FindSE(oMatrix, currentRow, currentCol, oWord, currentLetter);
                if (res != null)
                {
                    oLocations.Add(new Location(res.Row, res.Col, res.NextPosition));

                    palabraEncontrada += oWord[currentLetter];
                    if (palabra == palabraEncontrada)
                    {
                        return oLocations;
                    }

                    return FindWord(oMatrix, res.Row, res.Col, oWord, currentLetter + 1, "");
                }
                sDirection = "S";
            }

            if (sDirection == "S" || sDirection == "")
            {
                res = FindS(oMatrix, currentRow, currentCol, oWord, currentLetter);
                if (res != null)
                {
                    oLocations.Add(new Location(res.Row, res.Col, res.NextPosition));

                    palabraEncontrada += oWord[currentLetter];
                    if (palabra == palabraEncontrada)
                    {
                        return oLocations;
                    }

                    return FindWord(oMatrix, res.Row, res.Col, oWord, currentLetter + 1, "");
                }
                sDirection = "SW";
            }
            if (sDirection == "SW" || sDirection == "")
            {
                res = FindSW(oMatrix, currentRow, currentCol, oWord, currentLetter);
                if (res != null)
                {
                    oLocations.Add(new Location(res.Row, res.Col, res.NextPosition));

                    palabraEncontrada += oWord[currentLetter];
                    if (palabra == palabraEncontrada)
                    {
                        return oLocations;
                    }

                    return FindWord(oMatrix, res.Row, res.Col, oWord, currentLetter + 1, "");
                }
                sDirection = "W";
            }

            if (sDirection == "W" || sDirection == "")
            {
                res = FindW(oMatrix, currentRow, currentCol, oWord, currentLetter);
                if (res != null)
                {
                    oLocations.Add(new Location(res.Row, res.Col, res.NextPosition));

                    palabraEncontrada += oWord[currentLetter];
                    if (palabra == palabraEncontrada)
                    {
                        return oLocations;
                    }

                    return FindWord(oMatrix, res.Row, res.Col, oWord, currentLetter + 1, "");
                }
                sDirection = "NW";
            }

            if (sDirection == "NW" || sDirection == "")
            {
                res = FindNW(oMatrix, currentRow, currentCol, oWord, currentLetter);
                if (res != null)
                {
                    oLocations.Add(new Location(res.Row, res.Col, res.NextPosition));

                    palabraEncontrada += oWord[currentLetter];
                    if (palabra == palabraEncontrada)
                    {
                        return oLocations;
                    }

                    return FindWord(oMatrix, res.Row, res.Col, oWord, currentLetter + 1, "");
                }
                sDirection = "";
            }

            var nNextPosition = "";
            Location oLastValidPosition = null;
            
            if (oLocations.Count > 0) // no encontró la letra
            {
                if(oLocations.Count == 1)
                {
                    palabraEncontrada = "";
                    oLocations.Clear();
                    return null;
                }
                nNextPosition = oLocations.Last().NextPosition;
                oLocations.RemoveAt(oLocations.Count - 1);
                if (oLocations.Count == 0)
                {
                    palabraEncontrada = "";
                    oLocations.Clear();
                    return null;
                }
                oLastValidPosition = oLocations.Last();
                currentLetter--;
                palabraEncontrada = palabraEncontrada.Substring(0, palabraEncontrada.Length - 1);
            }
            if (oLocations.Count == 0)
            {
                palabraEncontrada = "";
                return null;
            }

            return FindWord(oMatrix, oLastValidPosition.Row, oLastValidPosition.Col, oWord, currentLetter, nNextPosition);
        }

        private string GetNextPosition(string sPosition)
        {
            switch(sPosition)
            {
                case "N":
                    return "NE";
                case "NE":
                    return "E";
                case "E":
                    return "SE";
                case "SE":
                    return "S";
                case "S":
                    return "SW";
                case "SW":
                    return "W";
                case "W":
                    return "NW";
                case "NW":
                    return "N";
                default: return "";
            }
        }

        public List<List<Location>> Resolve(Puzzle oPuzzle)
        {
            List<List<Location>> oSolutions = new List<List<Location>>();
            var oMatrix = oPuzzle.Lines.ConvertAll(item => item.ToCharArray()).ToArray();


            oPuzzle.Words.ForEach(item =>
            {
                var aWord = item.ToCharArray();
                oLocations.Clear();
                palabraEncontrada = "";

                List<Location> oFirstLetterLocation = new List<Location>();

                for (int i = 0; i < oPuzzle.Lines.Count; i++)
                {
                    for (int j = 0; j < oPuzzle.Lines[i].Length; j++)
                    {
                        if (oPuzzle.Lines[i][j] == aWord[0])
                        {
                            oFirstLetterLocation.Add(new Location(i, j, ""));
                        }
                    }
                }

                var tytyt = String.Join("", aWord);

                if (oFirstLetterLocation.Count > 0)
                {
                    foreach (var oFirstLocation in oFirstLetterLocation)
                    {
                        var sol = FindWord(oMatrix, oFirstLocation.Row, oFirstLocation.Col, aWord, 0, oFirstLocation.NextPosition);
                        if (sol != null)
                        {
                            oSolutions.Add(sol);
                            break;
                        }
                    }
                }
                else
                    oSolutions.Add(null);
            });

            return oSolutions;
        }

        /// <summary>
        /// Aplicar el algoritmo Markov para decifrar la Puzzle de letras
        /// </summary>
        /// <param name="oData"></param>
        /// <returns></returns>
        public Puzzle DecypherPuzzle()
        {
            Puzzle oSolution = new Puzzle();
            JSONData oData = GetData(HttpRuntime.AppDomainAppPath + "App_Data\\json\\");

            List<string> oResult = new List<string>();
            for (int i = 0; i < oData.oValues.Count; i++)
            {
                oData.oValues[i].Sort((a, b) => a.order > b.order ? 1 : a.order < b.order ? -1 : 0);
                string sResultLine = oData.oCypher[i];

                for (int j = 0; j < oData.oValues[i].Count; j++)
                {
                    var nRuleNumber = oData.oValues[i][j].rule;
                    sResultLine = sResultLine.Replace(oData.oBase[nRuleNumber].source, oData.oBase[nRuleNumber].replacement);
                }
                oResult.Add(sResultLine);
            }

            oSolution.Words = oData.oWords;
            oSolution.Lines = oResult;

            //Resolve(oSolution);

            return oSolution;
        }

        /// <summary>
        /// Obtiene los datos con los que se va a trabajar
        /// </summary>
        /// <returns>los datos como objetos</returns>
        private JSONData GetData(string sOrigin)
        { // http, fs, bd
            JSONData oData = new JSONData();

            using (StreamReader r = new StreamReader(sOrigin + "base.json"))
            {
                string json = r.ReadToEnd();
                oData.oBase = JsonConvert.DeserializeObject<List<Base>>(json);
            }
            using (StreamReader r = new StreamReader(sOrigin + "cypher.json"))
            {
                string json = r.ReadToEnd();
                oData.oCypher = JsonConvert.DeserializeObject<List<string>>(json);
            }
            using (StreamReader r = new StreamReader(sOrigin + "values.json"))
            {
                string json = r.ReadToEnd();
                oData.oValues = JsonConvert.DeserializeObject<List<List<Values>>>(json);
            }
            using (StreamReader r = new StreamReader(sOrigin + "words.json"))
            {
                string json = r.ReadToEnd();
                oData.oWords = JsonConvert.DeserializeObject<List<string>>(json);
            }

            return oData;
        }

        #region NESW
        public Location FindN(char[][] oMatrix, int currentRow, int currentCol, char[] oWord, int currentLetter)
        {
            if (currentRow == 0)
                return null;
            else if (oMatrix[currentRow - 1][currentCol] == oWord[currentLetter])
            {
                return new Location(currentRow - 1, currentCol, "NE");
            }
            else
                return null;
        }
        public Location FindNE(char[][] oMatrix, int currentRow, int currentCol, char[] oWord, int currentLetter)
        {
            if (currentRow == 0 || currentCol == (oMatrix[currentRow].Length - 1))
                return null;
            else if (oMatrix[currentRow - 1][currentCol + 1] == oWord[currentLetter])
            {
                return new Location(currentRow - 1, currentCol + 1, "E");
            }
            else
                return null;
        }
        public Location FindE(char[][] oMatrix, int currentRow, int currentCol, char[] oWord, int currentLetter)
        {
            if (currentCol == (oMatrix[currentRow].Length - 1))
                return null;
            else if (oMatrix[currentRow][currentCol + 1] == oWord[currentLetter])
            {
                return new Location(currentRow, currentCol + 1, "SE");
            }
            else
                return null;
        }
        public Location FindSE(char[][] oMatrix, int currentRow, int currentCol, char[] oWord, int currentLetter)
        {
            if ((oMatrix.Length-1) == currentRow || currentCol == (oMatrix[currentRow].Length - 1))
                return null;
            else if (oMatrix[currentRow + 1][currentCol + 1] == oWord[currentLetter])
            {
                return new Location(currentRow + 1, currentCol + 1, "S");
            }
            else
                return null;
        }
        public Location FindS(char[][] oMatrix, int currentRow, int currentCol, char[] oWord, int currentLetter)
        {
            if ((oMatrix.Length - 1) == currentRow)
                return null;
            else if (oMatrix[currentRow + 1][currentCol] == oWord[currentLetter])
            {
                return new Location(currentRow + 1, currentCol, "SW");
            }
            else
                return null;
        }
        public Location FindSW(char[][] oMatrix, int currentRow, int currentCol, char[] oWord, int currentLetter)
        {
            if ((oMatrix.Length - 1) == currentRow || (currentCol) == 0)
                return null;
            else if (oMatrix[currentRow + 1][currentCol - 1] == oWord[currentLetter])
            {
                return new Location(currentRow + 1, currentCol - 1, "W");
            }
            else
                return null;
        }
        public Location FindW(char[][] oMatrix, int currentRow, int currentCol, char[] oWord, int currentLetter)
        {
            if (currentCol == 0)
                return null;
            else if (oMatrix[currentRow][currentCol - 1] == oWord[currentLetter])
            {
                return new Location(currentRow, currentCol - 1, "NW");
            }
            else
                return null;
        }
        public Location FindNW(char[][] oMatrix, int currentRow, int currentCol, char[] oWord, int currentLetter)
        {
            if (currentRow == 0 || currentCol == 0)
                return null;
            else if (oMatrix[currentRow - 1][currentCol - 1] == oWord[currentLetter])
            {
                return new Location(currentRow - 1, currentCol - 1, "N");
            }
            else
                return null;
        }
        #endregion

        private List<Location> FindWord2(char[][] oMatrix, int currentRow, int currentCol, char[] oWord, int currentLetter, string sDirection)
        {
            var letra = oWord[currentLetter];
            palabra = String.Join("", oWord);
            //if(sDirection)
            if (currentRow >= oMatrix.Length || currentCol >= oMatrix[currentRow].Length) // no hay mas letras en la sopa
                return null;
            else if (currentCol == oMatrix[currentRow].Length - 1) // ultima columna
                return FindWord(oMatrix, currentRow + 1, 0, oWord, currentLetter, "N");

            if (oMatrix[currentRow][currentCol] == oWord[currentLetter]) // letra encontrada
            {
                if (currentLetter == 0)
                    oLocations.Add(new Location(currentRow, currentCol, "E"));
                else
                    oLocations.Add(new Location(currentRow, currentCol, GetNextPosition(sDirection)));

                palabraEncontrada += oWord[currentLetter];
                if (palabra == palabraEncontrada)
                {
                    //oLocations.Add(new Location(currentRow, currentCol, ""));
                    return oLocations;
                }

                return FindWord(oMatrix, currentRow, currentCol, oWord, currentLetter + 1, "N");
            }

            Location res = null;
            if (sDirection == "N" || sDirection == "")
            {
                res = FindN(oMatrix, currentRow, currentCol, oWord, currentLetter);
                if (res != null)
                {
                    oLocations.Add(res);
                    return FindWord(oMatrix, res.Row, res.Col, oWord, currentLetter, "");
                }
            }

            if (sDirection == "NE" || sDirection == "")
            {
                res = FindNE(oMatrix, currentRow, currentCol, oWord, currentLetter);
                if (res != null)
                {
                    oLocations.Add(res);
                    return FindWord(oMatrix, res.Row, res.Col, oWord, currentLetter, "");
                }
            }

            if (sDirection == "E" || sDirection == "")
            {
                res = FindE(oMatrix, currentRow, currentCol, oWord, currentLetter);
                if (res != null)
                {
                    oLocations.Add(res);
                    return FindWord(oMatrix, res.Row, res.Col, oWord, currentLetter, "");
                }
            }

            if (sDirection == "SE" || sDirection == "")
            {
                res = FindSE(oMatrix, currentRow, currentCol, oWord, currentLetter);
                if (res != null)
                {
                    oLocations.Add(res);
                    return FindWord(oMatrix, res.Row, res.Col, oWord, currentLetter, "");
                }
            }

            if (sDirection == "S" || sDirection == "")
            {
                res = FindS(oMatrix, currentRow, currentCol, oWord, currentLetter);
                if (res != null)
                {
                    oLocations.Add(res);
                    return FindWord(oMatrix, res.Row, res.Col, oWord, currentLetter, "");
                }
            }
            if (sDirection == "SW" || sDirection == "")
            {
                res = FindSW(oMatrix, currentRow, currentCol, oWord, currentLetter);
                if (res != null)
                {
                    oLocations.Add(res);
                    return FindWord(oMatrix, res.Row, res.Col, oWord, currentLetter, "");
                }
            }

            if (sDirection == "W" || sDirection == "")
            {
                res = FindW(oMatrix, currentRow, currentCol, oWord, currentLetter);
                if (res != null)
                {
                    oLocations.Add(res);
                    return FindWord(oMatrix, res.Row, res.Col, oWord, currentLetter, "");
                }
            }

            if (sDirection == "NW" || sDirection == "")
            {
                res = FindNW(oMatrix, currentRow, currentCol, oWord, currentLetter);
                if (res != null)
                {
                    oLocations.Add(res);
                    return FindWord(oMatrix, res.Row, res.Col, oWord, currentLetter, "");
                }
            }

            var nNextPosition = "";
            // no encontró la letra
            if (oLocations.Count > 0)
            {
                nNextPosition = oLocations.Last().NextPosition;
                if (oLocations.Count == 1)
                {
                    oLocations.RemoveAt(oLocations.Count - 1);
                    return null;
                }
                oLocations.RemoveAt(oLocations.Count - 1);
            }
            else
            {
                if (currentLetter > 0)
                    currentLetter--;
                nNextPosition = "N";
                palabraEncontrada = palabraEncontrada.Substring(0, palabraEncontrada.Length - 1);
            }

            return FindWord(oMatrix, currentRow, currentCol + 1, oWord, currentLetter, nNextPosition);
        }

        private List<Location> FindWord3(char[][] oMatrix, int currentRow, int currentCol, char[] oWord, int currentLetter, string sDirection)
        {
            var letra = oWord[currentLetter];
            palabra = String.Join("", oWord);
            //if(sDirection)
            if (currentRow >= oMatrix.Length || currentCol >= oMatrix[currentRow].Length) // no hay mas letras en la sopa
                return null;
            else if (currentCol == oMatrix[currentRow].Length - 1) // ultima columna
                return FindWord(oMatrix, currentRow + 1, 0, oWord, currentLetter, "N");

            if (oMatrix[currentRow][currentCol] == oWord[currentLetter]) // letra encontrada
            {
                if (currentLetter == 0)
                    oLocations.Add(new Location(currentRow, currentCol, "E"));
                else
                    oLocations.Add(new Location(currentRow, currentCol, GetNextPosition(sDirection)));

                palabraEncontrada += oWord[currentLetter];
                if (palabra == palabraEncontrada)
                {
                    //oLocations.Add(new Location(currentRow, currentCol, ""));
                    return oLocations;
                }

                return FindWord(oMatrix, currentRow, currentCol, oWord, currentLetter + 1, "N");
            }

            Location res = null;
            if (sDirection == "N" || sDirection == "")
            {
                res = FindN(oMatrix, currentRow, currentCol, oWord, currentLetter);
                if (res != null)
                {
                    //oLocations.Add(res);
                    return FindWord(oMatrix, res.Row, res.Col, oWord, currentLetter, "");
                }
                sDirection = "NE";
            }

            if (sDirection == "NE" || sDirection == "")
            {
                res = FindNE(oMatrix, currentRow, currentCol, oWord, currentLetter);
                if (res != null)
                {
                    //oLocations.Add(res);
                    return FindWord(oMatrix, res.Row, res.Col, oWord, currentLetter, "");
                }
                sDirection = "E";
            }

            if (sDirection == "E" || sDirection == "")
            {
                res = FindE(oMatrix, currentRow, currentCol, oWord, currentLetter);
                if (res != null)
                {
                    //oLocations.Add(res);
                    return FindWord(oMatrix, res.Row, res.Col, oWord, currentLetter, "");
                }
                sDirection = "SE";
            }

            if (sDirection == "SE" || sDirection == "")
            {
                res = FindSE(oMatrix, currentRow, currentCol, oWord, currentLetter);
                if (res != null)
                {
                    //oLocations.Add(res);
                    return FindWord(oMatrix, res.Row, res.Col, oWord, currentLetter, "");
                }
                sDirection = "S";
            }

            if (sDirection == "S" || sDirection == "")
            {
                res = FindS(oMatrix, currentRow, currentCol, oWord, currentLetter);
                if (res != null)
                {
                    //oLocations.Add(res);
                    return FindWord(oMatrix, res.Row, res.Col, oWord, currentLetter, "");
                }
                sDirection = "SW";
            }
            if (sDirection == "SW" || sDirection == "")
            {
                res = FindSW(oMatrix, currentRow, currentCol, oWord, currentLetter);
                if (res != null)
                {
                    //oLocations.Add(res);
                    return FindWord(oMatrix, res.Row, res.Col, oWord, currentLetter, "");
                }
                sDirection = "W";
            }

            if (sDirection == "W" || sDirection == "")
            {
                res = FindW(oMatrix, currentRow, currentCol, oWord, currentLetter);
                if (res != null)
                {
                    //oLocations.Add(res);
                    return FindWord(oMatrix, res.Row, res.Col, oWord, currentLetter, "");
                }
                sDirection = "NW";
            }

            if (sDirection == "NW" || sDirection == "")
            {
                res = FindNW(oMatrix, currentRow, currentCol, oWord, currentLetter);
                if (res != null)
                {
                    //oLocations.Add(res);
                    return FindWord(oMatrix, res.Row, res.Col, oWord, currentLetter, "");
                }
                sDirection = "";
            }

            var nNextPosition = "";
            // no encontró la letra
            if (oLocations.Count > 0)
            {
                nNextPosition = oLocations.Last().NextPosition;
                if (oLocations.Count == 1)
                {
                    oLocations.RemoveAt(oLocations.Count - 1);
                    palabraEncontrada = "";
                    return null;
                }
                //oLocations.RemoveAt(oLocations.Count - 1);
                //palabraEncontrada = palabraEncontrada.Substring(0, palabraEncontrada.Length - 1);
            }
            else
            {
                if (currentLetter > 0)
                    currentLetter--;
                nNextPosition = "N";
                palabraEncontrada = palabraEncontrada.Substring(0, palabraEncontrada.Length - 1);
            }

            return FindWord(oMatrix, currentRow, currentCol + 1, oWord, currentLetter, nNextPosition);
        }

    }
}