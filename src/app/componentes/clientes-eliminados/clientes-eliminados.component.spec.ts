import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientesEliminadosComponent } from './clientes-eliminados.component';

describe('ClientesEliminadosComponent', () => {
  let component: ClientesEliminadosComponent;
  let fixture: ComponentFixture<ClientesEliminadosComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ClientesEliminadosComponent]
    });
    fixture = TestBed.createComponent(ClientesEliminadosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
