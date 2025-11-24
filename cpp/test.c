#include <stdio.h>
#include <stdlib.h>

int main()
{
  int n;
  scanf("%d", &n);
  double *a = malloc(n * sizeof(double));
  for (int i = 0; i <= n + 1; i++)
  {
    printf("%d", i);
    a[i] = i;
  }
  free((void *)(a));
}