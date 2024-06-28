//*****************************************************************************
//** 2285. Maximum Total Impotance of Roads leetcode                         **
//** Loop and a Hash Table to solve the roads problem. Where I started and   **
//** where I ended, but I did have some problems with getting numbers        **
//** assigned correctly.   -Dan                                              **
//*****************************************************************************

long long maximumImportance(int n, int** roads, int roadsSize, int* roadsColSize) {
      int* degree = (int*)calloc(n, sizeof(int));
    int maxdegree = 0;
    for (int i = 0; i < roadsSize; i++) {
        degree[roads[i][0]]++;
        degree[roads[i][1]]++;
        if (degree[roads[i][0]] > maxdegree) {
            maxdegree = degree[roads[i][0]];
        }
        if (degree[roads[i][1]] > maxdegree) {
            maxdegree = degree[roads[i][1]];
        }
    }
    
    int* rank = (int*)calloc(n, sizeof(int));
    int i = n;
    while (i > 0) {
        for (int j = 0; j < n; j++) {
            if (degree[j] == maxdegree) {
                rank[j] = i--;
                degree[j] = INT_MIN;
            }
        }
        maxdegree = 0;
        for (int j = 0; j < n; j++) {
            if (degree[j] > maxdegree) {
                maxdegree = degree[j];
            }
        }
    }
    
    long long res = 0;
    for (int i = 0; i < roadsSize; i++) {
        res += rank[roads[i][0]] + rank[roads[i][1]];
    }
    
    free(degree);
    free(rank);
    return res; 
}