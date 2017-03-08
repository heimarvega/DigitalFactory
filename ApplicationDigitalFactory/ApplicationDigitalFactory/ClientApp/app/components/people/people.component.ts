import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { URLSearchParams, QueryEncoder } from '@angular/http';
@Component({
    selector: 'people',
    template: require('./people.component.html')
})
export class PeopleComponent {
    public peoples: IPeople[];
    public titulo: string;
    public totalAmount: string;
    constructor(private http: Http) {
        http.get('/api/People/People').subscribe(result => {
            this.peoples = result.json();
        });
        this.titulo = 'Find in People -  Digital Factory';
    }
    public getTotalAmount(name: string, region: string) {
        let params = new URLSearchParams();
        params.set('name', name);
        params.set('region', region);
        this.http.get('api/People/byNameAndRegion', { search: params }).subscribe(result => {
            this.totalAmount = result.json();
        });
    }
}

interface IPeople {
    id: number,
    name: string,
    region: string,
    amount: number,
}