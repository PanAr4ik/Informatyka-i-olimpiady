#include <vector> 
#include <string>
#include <iostream> 

class Solution {
public:
    void dfs(std::vector<std::vector<char>>& grid, int r, int c) {
        int num_rows = grid.size();
        int num_cols = grid[0].size();


        if (r < 0 || r >= num_rows || c < 0 || c >= num_cols || grid[r][c] != '1') {
            return;
        }

        grid[r][c] = '0';

        dfs(grid, r + 1, c); 
        dfs(grid, r - 1, c); 
        dfs(grid, r, c + 1); 
        dfs(grid, r, c - 1); 
    }

    int numIslands(std::vector<std::vector<char>>& grid) {
        if (grid.empty() || grid[0].empty()) {
            return 0; 
        }

        int num_rows = grid.size();
        int num_cols = grid[0].size();
        int num_islands = 0;

        for (int r = 0; r < num_rows; ++r) {
            for (int c = 0; c < num_cols; ++c) {
                if (grid[r][c] == '1') {
                    num_islands++; 
                   
                    dfs(grid, r, c);
                }
            }
        }

        return num_islands;
    }
};