import {ComponentFixture, TestBed} from '@angular/core/testing';

import {ListCarloadsComponent} from './list-carloads.component';

describe('ListCarloadsComponent', () => {
  let component: ListCarloadsComponent;
  let fixture: ComponentFixture<ListCarloadsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListCarloadsComponent]
    });
    fixture = TestBed.createComponent(ListCarloadsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
