import { Component } from "@angular/core"

@Component({
  selector: "produto",
  template: " <html><body>{{obterNome()}}}</body></html>",
    

})
export class ProdutoComponent { //export-> é parecido com o public, disponibilizando q possa ser usada por outros componentes do modulo e
                                //Nome das classes começando com maiusculo por conta da convenção PascalCase

/* camelCase para variaveis, atributos e nomes da funções*/
  public nome: string;
  public liberadoParaVenda: boolean;

  public obterNome(): string {
    return "Samsung"; 
  }

}
