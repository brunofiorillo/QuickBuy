import { Component, OnInit } from "@angular/core";
import { Produto } from "../modelo/produto";
import { ProdutoServico } from "../servicos/produto/produto.servico";

@Component({
  selector: "produto",
  templateUrl: './produto.component.html',
  styleUrls: ["./produto.component.css"]
})
   //export-> é parecido com o public, disponibilizando q possa ser usada por outros componentes do modulo e
 //Nome das classes começando com maiusculo por conta da convenção PascalCase
export class ProdutoComponent implements OnInit{

  public produto: Produto
  public arquivoSelecionado: File;

  constructor(private produtoServico: ProdutoServico) {
  }

  ngOnInit(): void {
    this.produto = new Produto();
  } 

  public inputChange(files: FileList) {
    this.arquivoSelecionado = files.item(0);
    this.produtoServico.enviarArquivo(this.arquivoSelecionado)
      .subscribe(
        retorno => { 
          console.log(retorno);
        },
        e => {
          console.log(e.error);
        });
  }

  public cadastrar() {
    this.produtoServico.cadastrar(this.produto)
      .subscribe(
        produtoJson => {
          console.log(produtoJson);

        },

        e => {
          console.log(e.error);
        }

      );
  }

}
