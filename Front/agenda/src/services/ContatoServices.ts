
import http from './http';


export default class ContatoService {

    getAll() {
        return http.get('api/Cliente');
    }

    save(contato: any) {
        return http.post('api/Cliente',contato)
    }

    update(contato: any){
        return http.put('api/Cliente', contato)
    }
}
