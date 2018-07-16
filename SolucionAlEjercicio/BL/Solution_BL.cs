using Newtonsoft.Json;
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
        public List<List<Location>> ResolvePuzzle(Puzzle oPuzzle)
        {
            List<List<Location>> oSolutions = new List<List<Location>>();
            var oMatrix = oPuzzle.Lines.ConvertAll(item => item.ToCharArray()).ToArray();

            oPuzzle.Words.ForEach(item => 
            {
                var aWord = item.ToCharArray();

                List<Location> oFirstLetterLocation = new List<Location>();

                // find for all the occurences of the first letter of the word to find
                for (int i = 0; i < oPuzzle.Lines.Count; i++)
                {
                    for (int j = 0; j < oPuzzle.Lines[i].Length; j++)
                    {
                        if (oPuzzle.Lines[i][j] == aWord[0])
                        {
                            oFirstLetterLocation.Add(new Location(i, j, aWord[0], ""));
                        }
                    }
                }

                // according to the initial letter found, complete the search of every word and posibility
                if (oFirstLetterLocation.Count > 0)
                {
                    foreach (var oFirstLocation in oFirstLetterLocation)
                    {
                        var oSolution = FindWord(oMatrix, oFirstLocation.row, oFirstLocation.column, aWord, 0, oFirstLocation.NextPosition, new List<Location>());
                        if (oSolution != null)
                        {
                            oSolutions.Add(oSolution); // solution found
                            break; // next word
                        }
                    }

                    //oSolutions.Add(null);  // no solutions found for this word
                }
                else
                    oSolutions.Add(null);
            });

            return oSolutions;
        }

        /// <summary>
        /// Recursive algorithm to find a word on the puzzle
        /// </summary>
        /// <param name="oMatrix"></param>
        /// <param name="currentRow"></param>
        /// <param name="currentCol"></param>
        /// <param name="oWord"></param>
        /// <param name="currentLetterIndex"></param>
        /// <param name="sDirection"></param>
        /// <param name="oLocations"></param>
        /// <returns></returns>
        private List<Location> FindWord(char[][] oMatrix, int currentRow, int currentCol, char[] oWord, int currentLetterIndex, string sDirection, List<Location> oLocations)
        {
            string sCurrentWord = String.Join("", oWord);

            if(currentLetterIndex == 0)
            {
                oLocations.Add(new Location(currentRow, currentCol, oWord[currentLetterIndex], "N"));
                if (sCurrentWord == GetStringFromLocationsList(oLocations))
                    return oLocations;

                return FindWord(oMatrix, currentRow, currentCol, oWord, currentLetterIndex + 1, "", oLocations);

            }

            Location oLetterLocation = null;
            if (sDirection == "")
            {
                oLetterLocation = FindN(oMatrix, currentRow, currentCol, oWord, currentLetterIndex);
                if (oLetterLocation != null)
                {
                    oLocations.Add(oLetterLocation);
                    if (sCurrentWord == GetStringFromLocationsList(oLocations))
                        return oLocations;

                    return FindWord(oMatrix, oLetterLocation.row, oLetterLocation.column, oWord, currentLetterIndex + 1, "", oLocations);
                }
                sDirection = "NE";
            }

            if (sDirection == "NE" || sDirection == "")
            {
                oLetterLocation = FindNE(oMatrix, currentRow, currentCol, oWord, currentLetterIndex);
                if (oLetterLocation != null)
                {
                    oLocations.Add(oLetterLocation);
                    if (sCurrentWord == GetStringFromLocationsList(oLocations))
                        return oLocations;

                    return FindWord(oMatrix, oLetterLocation.row, oLetterLocation.column, oWord, currentLetterIndex + 1, "", oLocations);
                }
                sDirection = "E";
            }

            if (sDirection == "E" || sDirection == "")
            {
                oLetterLocation = FindE(oMatrix, currentRow, currentCol, oWord, currentLetterIndex);
                if (oLetterLocation != null)
                {
                    oLocations.Add(oLetterLocation);
                    if (sCurrentWord == GetStringFromLocationsList(oLocations))
                        return oLocations;

                    return FindWord(oMatrix, oLetterLocation.row, oLetterLocation.column, oWord, currentLetterIndex + 1, "", oLocations);
                }
                sDirection = "SE";
            }

            if (sDirection == "SE" || sDirection == "")
            {
                oLetterLocation = FindSE(oMatrix, currentRow, currentCol, oWord, currentLetterIndex);
                if (oLetterLocation != null)
                {
                    oLocations.Add(oLetterLocation);
                    if (sCurrentWord == GetStringFromLocationsList(oLocations))
                        return oLocations;

                    return FindWord(oMatrix, oLetterLocation.row, oLetterLocation.column, oWord, currentLetterIndex + 1, "", oLocations);
                }
                sDirection = "S";
            }

            if (sDirection == "S" || sDirection == "")
            {
                oLetterLocation = FindS(oMatrix, currentRow, currentCol, oWord, currentLetterIndex);
                if (oLetterLocation != null)
                {
                    oLocations.Add(oLetterLocation);
                    if (sCurrentWord == GetStringFromLocationsList(oLocations))
                        return oLocations;

                    return FindWord(oMatrix, oLetterLocation.row, oLetterLocation.column, oWord, currentLetterIndex + 1, "", oLocations);
                }
                sDirection = "SW";
            }
            if (sDirection == "SW" || sDirection == "")
            {
                oLetterLocation = FindSW(oMatrix, currentRow, currentCol, oWord, currentLetterIndex);
                if (oLetterLocation != null)
                {
                    oLocations.Add(oLetterLocation);
                    if (sCurrentWord == GetStringFromLocationsList(oLocations))
                        return oLocations;

                    return FindWord(oMatrix, oLetterLocation.row, oLetterLocation.column, oWord, currentLetterIndex + 1, "", oLocations);
                }
                sDirection = "W";
            }

            if (sDirection == "W" || sDirection == "")
            {
                oLetterLocation = FindW(oMatrix, currentRow, currentCol, oWord, currentLetterIndex);
                if (oLetterLocation != null)
                {
                    oLocations.Add(oLetterLocation);
                    if (sCurrentWord == GetStringFromLocationsList(oLocations))
                        return oLocations;

                    return FindWord(oMatrix, oLetterLocation.row, oLetterLocation.column, oWord, currentLetterIndex + 1, "", oLocations);
                }
                sDirection = "NW";
            }

            if (sDirection == "NW" || sDirection == "")
            {
                oLetterLocation = FindNW(oMatrix, currentRow, currentCol, oWord, currentLetterIndex);
                if (oLetterLocation != null)
                {
                    oLocations.Add(oLetterLocation);
                    if (sCurrentWord == GetStringFromLocationsList(oLocations))
                        return oLocations;

                    return FindWord(oMatrix, oLetterLocation.row, oLetterLocation.column, oWord, currentLetterIndex + 1, "", oLocations);
                }
                sDirection = "";
            }

            var nNextPosition = "";
            Location oLastValidPosition = null;

            // letter not found
            if(oLocations.Count == 1) // if there's only one letter left --> the added at first 
            { //search for another word
                return null;
            }

            //searches for the next position and letter to look for 
            nNextPosition = oLocations.Last().NextPosition;
            oLocations.RemoveAt(oLocations.Count - 1);
            oLastValidPosition = oLocations.Last();
            currentLetterIndex--;

            return FindWord(oMatrix, oLastValidPosition.row, oLastValidPosition.column, oWord, currentLetterIndex, nNextPosition, oLocations);
        }

        /// <summary>
        /// Apply Markov's algorithm to find the puzzle
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
        /// Gets the data needeed
        /// </summary>
        /// <returns></returns>
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

        private Location FindN(char[][] oMatrix, int currentRow, int currentCol, char[] oWord, int currentLetterIndex)
        {
            if (currentRow == 0)
                return null;
            else if (oMatrix[currentRow - 1][currentCol] == oWord[currentLetterIndex])
            {
                return new Location(currentRow - 1, currentCol, oWord[currentLetterIndex], "NE");
            }
            else
                return null;
        }
        private Location FindNE(char[][] oMatrix, int currentRow, int currentCol, char[] oWord, int currentLetterIndex)
        {
            if (currentRow == 0 || currentCol == (oMatrix[currentRow].Length - 1))
                return null;
            else if (oMatrix[currentRow - 1][currentCol + 1] == oWord[currentLetterIndex])
            {
                return new Location(currentRow - 1, currentCol + 1, oWord[currentLetterIndex], "E");
            }
            else
                return null;
        }
        private Location FindE(char[][] oMatrix, int currentRow, int currentCol, char[] oWord, int currentLetterIndex)
        {
            if (currentCol == (oMatrix[currentRow].Length - 1))
                return null;
            else if (oMatrix[currentRow][currentCol + 1] == oWord[currentLetterIndex])
            {
                return new Location(currentRow, currentCol + 1, oWord[currentLetterIndex], "SE");
            }
            else
                return null;
        }
        private Location FindSE(char[][] oMatrix, int currentRow, int currentCol, char[] oWord, int currentLetterIndex)
        {
            if ((oMatrix.Length-1) == currentRow || currentCol == (oMatrix[currentRow].Length - 1))
                return null;
            else if (oMatrix[currentRow + 1][currentCol + 1] == oWord[currentLetterIndex])
            {
                return new Location(currentRow + 1, currentCol + 1, oWord[currentLetterIndex], "S");
            }
            else
                return null;
        }
        private Location FindS(char[][] oMatrix, int currentRow, int currentCol, char[] oWord, int currentLetterIndex)
        {
            if ((oMatrix.Length - 1) == currentRow)
                return null;
            else if (oMatrix[currentRow + 1][currentCol] == oWord[currentLetterIndex])
            {
                return new Location(currentRow + 1, currentCol, oWord[currentLetterIndex], "SW");
            }
            else
                return null;
        }
        private Location FindSW(char[][] oMatrix, int currentRow, int currentCol, char[] oWord, int currentLetterIndex)
        {
            if ((oMatrix.Length - 1) == currentRow || (currentCol) == 0)
                return null;
            else if (oMatrix[currentRow + 1][currentCol - 1] == oWord[currentLetterIndex])
            {
                return new Location(currentRow + 1, currentCol - 1, oWord[currentLetterIndex], "W");
            }
            else
                return null;
        }
        private Location FindW(char[][] oMatrix, int currentRow, int currentCol, char[] oWord, int currentLetterIndex)
        {
            if (currentCol == 0)
                return null;
            else if (oMatrix[currentRow][currentCol - 1] == oWord[currentLetterIndex])
            {
                return new Location(currentRow, currentCol - 1, oWord[currentLetterIndex], "NW");
            }
            else
                return null;
        }
        private Location FindNW(char[][] oMatrix, int currentRow, int currentCol, char[] oWord, int currentLetterIndex)
        {
            if (currentRow == 0 || currentCol == 0)
                return null;
            else if (oMatrix[currentRow - 1][currentCol - 1] == oWord[currentLetterIndex])
            {
                return new Location(currentRow - 1, currentCol - 1, oWord[currentLetterIndex], "N");
            }
            else
                return null;
        }

        
        #endregion

        private string GetStringFromLocationsList(List<Location> oLocationsList)
        {
            return String.Join("", oLocationsList.ConvertAll(item => item.character));
        }
    }
}