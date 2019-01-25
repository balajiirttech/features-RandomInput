int min(int A, int B) {
  return A < B ? A : B;
}

int removeObstacleUtil(int numRows, int numColumns, int **lot, int row, int col) {
  if (!row && !col)
    return 1 + min(removeObstacleUtil(numRows, numColumns, lot, row + 1, col),
                   removeObstacleUtil(numRows, numColumns, lot, row, col + 1));
  else if (row == numRows - 1 && col == numColumns - 1)
    return -1;
  else if (row == numRows - 1)
    return 1 + removeObstacleUtil(numRows, numColumns, lot, row, col + 1);
  else if (col == numColumns - 1)
    return 1 + removeObstacleUtil(numRows, numColumns, lot, row + 1, col);
  else if (lot[row][col] == 9)
    return 0;
  else
    return 1 + min(removeObstacleUtil(numRows, numColumns, lot, row + 1, col),
                   removeObstacleUtil(numRows, numColumns, lot, row, col + 1));
}

int removeObstacle(int numRows, int numColumns, int **lot) {
  if (numRows < 1 || numColumns > 1000 || numColumns < 1)
    return -1;
  return removeObstacleUtil(numRows, numColumns, lot, 0, 0);
}
