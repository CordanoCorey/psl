import { build, LookupValue } from '@caiu/library';

export const WIDGETS = [
  build(LookupValue, { id: 1, name: 'routings-grid', label: 'Routings Grid' }),
  build(LookupValue, { id: 2, name: 'routings-map', label: 'Routings Map' }),
  build(LookupValue, { id: 3, name: 'carriers-marketshare', label: 'Carriers Market Share' }),
  build(LookupValue, { id: 4, name: 'orders-grid', label: 'Orders Grid' }),
  build(LookupValue, { id: 5, name: 'order-statuses', label: 'Order Statuses' }),
  build(LookupValue, { id: 6, name: 'flagged-orders', label: 'Flagged Orders' }),
  build(LookupValue, { id: 7, name: 'distributor-inventory', label: 'Distribution Center Inventory' })
];
