import { Collection, QueryModel } from '@caiu/library';

export class Routing {
  id = 0;
  carrierId = 0;
  carrierName = '';
  destinationCity = '';
  destinationId = 0;
  destinationName = '';
  destinationStateId = 0;
  destinationStateName = '';
  endTime: Date;
  originId = 0;
  originCity = '';
  originName = '';
  originStateId = 0;
  originStateName = '';
  startTime: Date;

  get carrierSrc(): string {
    switch (this.carrierId) {
      case 1:
        return 'assets/carriers/truck-diamond.png';
      case 2:
        return 'assets/carriers/truck-warren.png';
      case 3:
        return 'assets/carriers/truck-ats.png';
    }
  }

  get originSrc(): string {
    switch (this.originId) {
      case 1:
        return 'assets/building-john-deere.png';
      case 2:
        return 'assets/building-psl.png';
    }
  }

  get destinationSrc(): string {
    switch (this.destinationId) {
      case 1:
        return 'assets/dealers/dealer-deer-country.png';
      case 2:
        return 'assets/dealers/dealer-shoppas.png';
      case 3:
        return 'assets/dealers/dealer-campbell.png';
    }
  }
}

export class Routings extends Collection<Routing> {
  constructor() {
    super(Routing);
  }
}

export class RoutingsQuery extends QueryModel<Routing> {
}
