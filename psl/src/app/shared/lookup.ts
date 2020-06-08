import { build, LookupValue } from '@caiu/library';

export const WIDGETS = [
  build(LookupValue, { id: 1, name: 'routings-grid', label: 'Routings' }),
  build(LookupValue, { id: 2, name: 'routings-map', label: 'Routings Map' })
];
