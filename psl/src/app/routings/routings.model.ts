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
}

export class Routings extends Collection<Routing> {

}

export class RoutingsQuery extends QueryModel<Routing> {
}
