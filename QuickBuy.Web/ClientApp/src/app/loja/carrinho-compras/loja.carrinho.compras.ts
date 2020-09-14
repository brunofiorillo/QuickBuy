import { Produto } from "../../modelo/produto";
import { Local } from "protractor/built/driverProviders";

export class LojaCarrinhoCompras {
  public produtos: Produto[] = [];

  public adicionar(produto: Produto) {
    var produtoLocalStorage = localStorage.getItem("produtoLocalStorage");
    if (!produtoLocalStorage) {
      //se nao existir nada dentro do localstorage
      this.produtos.push(produto);
    } else {
      //se ja existir pelo menos um unico item armazenado na sessao(localstorage)
      this.produtos = JSON.parse(produtoLocalStorage);
      this.produtos.push(produto);
    }
    localStorage.setItem("produtoLocalStorage", JSON.stringify(this.produtos)); 
  }

  public obterProdutos(): Produto[] {
    var produtoLocalStorage = localStorage.getItem("produtoLocalStorage");
    if (produtoLocalStorage) {
        return JSON.parse(produtoLocalStorage);
      return this.produtos;
    }
  }

  public removerProduto(produto) {
    var produtoLocalStorage = localStorage.getItem("produtoLocalStorage");
    if (produtoLocalStorage) {
      this.produtos = JSON.parse(produtoLocalStorage); 
      this.produtos = this.produtos.filter(p => p.id != produto.id);
      localStorage.setItem("produtoLocalStorage", JSON.stringify(this.produtos));
    }
  }

  public atualizar(produtos: Produto[]) {
    localStorage.setItem("produtoLocalStorage", JSON.stringify(produtos));
  }

  public temItensCarrinhoCompras(): boolean {
    var intens = this.obterProdutos();
    return (intens.length > 0);
  }
}
