import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { Usuario } from "../../modelo/usuario";
import { Session } from "protractor";


@Injectable({
  providedIn: "root"
    // significa q vai ser publicado na raiz(root) e todo o sistema pode usar
})
       
export class UsuarioServico {

    private baseUrl: string;
    private _usuario: Usuario;

  // usado o get para uma requizição de leitura e o set é executado para atribuição

    set usuario(usuario: Usuario) {
      sessionStorage.setItem("usuario-autenticado", JSON.stringify(usuario)); //convertendo do type script para o json
      this._usuario = usuario; 
    }

    get usuario(): Usuario {
      let usuario_json = sessionStorage.getItem("usuario-autenticado");
      this._usuario = JSON.parse(usuario_json);  //convertendo do json para o typescript
      return this._usuario;  
    }

    public usuario_autenticado() : boolean {
      return this._usuario != null && this._usuario.email != "" && this._usuario.senha != ""; 

    }

    public limpar_sessao() {
      sessionStorage.setItem("usuario-autenticado", "");
      this._usuario = null;
  }

    get headers(): HttpHeaders {
    return new HttpHeaders().set('content-type', 'application/json')
    }
    
    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
      this.baseUrl = baseUrl;  
    } 

    public verificarUsuario(usuario: Usuario): Observable<Usuario> {
      const headers = new HttpHeaders().set('content-type', 'application/json');

    var body = {
      email: usuario.email, 
      senha: usuario.senha
    }
        //this.baseUrl = raiz do site que pode ser exemplo.: www.quickbuy.com.br
      return this.http.post<Usuario>(this.baseUrl + "api/usuario/verificarUsuario" , body, { headers });
    
    }

  public cadastrarUsuario(usuario: Usuario): Observable<Usuario> {
 
    return this.http.post<Usuario>(this.baseUrl + "api/usuario", JSON.stringify(usuario), { headers: this.headers });
     //como n foi espicificado como acima api/usuario/verificarusuario ele vai no usuario controller e vai pegar o post 

  }

}
