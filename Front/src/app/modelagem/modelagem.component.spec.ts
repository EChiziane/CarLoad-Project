import {ComponentFixture, TestBed} from '@angular/core/testing';

import {ModelagemComponent} from './modelagem.component';

describe('ModelagemComponent', () => {
  let component: ModelagemComponent;
  let fixture: ComponentFixture<ModelagemComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ModelagemComponent]
    });
    fixture = TestBed.createComponent(ModelagemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
