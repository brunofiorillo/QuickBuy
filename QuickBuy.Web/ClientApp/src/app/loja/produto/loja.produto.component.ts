import { Component, OnInit } from '@angular/core';
import { Produto } from '../../modelo/produto';
import { ProdutoServico } from '../../servicos/produto/produto.servico';
import { Router } from '@angular/router';
import { LojaCarrinhoCompras } from '../carrinho-compras/loja.carrinho.compras';

@Component({
  selector: "loja-app-produto",
  templateUrl: "./loja.produto.component.html",
  styleUrls: ["./loja.produto.component.css"]
})

export class LojaProdutoComponent implements OnInit {
  public produto: Produto;
  public carrinhoCompras: LojaCarrinhoCompras;

  ngOnInit(): void {
    this.carrinhoCompras = new LojaCarrinhoCompras();
    var produtoDetalhe = sessionStorage.getItem('ProdutoDetalhe');
    if (produtoDetalhe) {
      this.produto = JSON.parse(produtoDetalhe);
    }
      
  }
  constructor (private produtoServico: ProdutoServico, public router : Router) {

  }
  public voltarPrincipal() {
    this.router.navigate(['/app-home']);
  }

  public comprar() {
    this.carrinhoCompras.adicionar(this.produto);
    this.router.navigate(['/loja-efetivar']);
  }
}
