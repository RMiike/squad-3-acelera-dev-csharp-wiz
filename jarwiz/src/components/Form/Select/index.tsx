import React, { SelectHTMLAttributes, } from 'react';
import { SelectBlock } from './styles';

interface SelectProps extends SelectHTMLAttributes<HTMLSelectElement> {
  name: string;
  label: string;
  options: Array<{
    value: string;
    label: string;
  }>;
}

const Select: React.FC<SelectProps> =
  ({ label, name, options, ...rest }) => {
    return (
      <SelectBlock>
        <label htmlFor={name}>{label}</label>
        <select id={name} {...rest}>
          <option value="" disabled hidden>Selecione uma opção</option>
          {options.map((x, i) => {
            return (
              <option key={i} value={x.value}>{x.label}</option>
            )
          })}
        </select>
      </SelectBlock>
    );
  }

export default Select;