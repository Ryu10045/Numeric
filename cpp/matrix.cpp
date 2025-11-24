#include <stdlib.h>

#include <algorithm>
#include <iostream>
#include <stdexcept>
#include <string>
#include <type_traits>
#include <vector>

using namespace std;

template <class T>
class Matrix {
 private:
  size_t rows_;
  size_t cols_;
  std::vector<T> data_;

 public:
  Matrix(size_t rows, size_t cols)
      : rows_(rows), cols_(cols), data_(rows * cols) {}

  Matrix(size_t rows, size_t cols, T initial)
      : rows_(rows), cols_(cols), data_(rows * cols, initial) {}

  T* operator[](size_t i) { return &data_[i * cols_]; }
  const T* operator[](size_t i) const { return &data_[i * cols_]; }

  size_t size_row() const { return rows_; }
  size_t size_col() const { return cols_; }

  std::vector<T>& getData() { return data_; }
};

template <class Scalar, class T>
auto operator*(Scalar s, Matrix<T>& m) {
  using ResultType = decltype(s * std::declval<T>());

  Matrix<ResultType> result(m.size_row, m.size_col);

  const auto& src_vec = m.getData();
  auto& res_vec = result.getData();

  for (int i = 0; i < src_vec.size(); i++) {
    res_vec[i] = s * src_vec[i];
  }

  return result;
}

template <class Scalar, class T>
auto operator*(Matrix<T>& m, Scalar s) {
  return s * m;
}

template <class S, class T>
auto operator*(Matrix<S>& m, Matrix<T>& n) {
  if (m.size_col() != n.size_row()) {
    throw std::invalid_argument(
      "Matrix size mismatch: " + 
      std::to_string(m.size_row()) + "x" + std::to_string(m.size_col()) + 
      " and " + 
      std::to_string(n.size_row()) + "x" + std::to_string(n.size_col())
      );
  }

  using result_type = decltype(std::declval<S>() * std::declval<T>());

  Matrix<result_type> result(m.size_col(), n.size_row());

  for(int i=0;i<result.size_row();i++){
    for(int j=0;j<result.size_col();j++){
      result_type tmp = {};
      for(int k=0;k<m.size_col();k++){
        tmp += m[i][k] * n[k][j];
      }
      result[i][j] = tmp;
    }
  }

  return result;
}


int main(int argc, char* argv[]) {
  auto a = Matrix<int>(2,2);
  a[0][0] = 1;
  a[0][1] = 2;
  a[1][0] = 3;
  a[1][1] = 4;

  auto b = Matrix<double>(2,3);
  b[0][0] = 1.5;
  b[0][1] = 2.3;
  b[0][2] = 3.3;
  b[1][0] = 4.4;
  b[1][1] = 5.9;
  b[1][2] = 6.1;

  auto ab = a * b;
  for(int i=0;i<ab.size_col();i++){
    for(int j=0;j<ab.size_row();j++){
      cout << ab[i][j] << " ";
    }
    cout <<endl;
  }
}