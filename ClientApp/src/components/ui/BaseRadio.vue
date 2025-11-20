<script setup lang="ts">
interface Option {
  value: string | number;
  label: string;
}

defineProps<{
  modelValue: string | number;
  options: Option[];
  name: string;
}>();

defineEmits<{
  (e: 'update:modelValue', value: string | number): void;
}>();
</script>

<template>
  <div class="base-radio-group">
    <label v-for="option in options" :key="option.value" class="radio-label">
      <input
        type="radio"
        :name="name"
        :value="option.value"
        :checked="modelValue === option.value"
        @change="$emit('update:modelValue', option.value)"
      />
      <span class="radio-custom"></span>
      <span class="label-text">{{ option.label }}</span>
    </label>
  </div>
</template>

<style scoped lang="scss">
.base-radio-group {
  display: flex;
  flex-direction: column;
  gap: 0.5rem;
}

.radio-label {
  display: flex;
  align-items: center;
  cursor: pointer;
  user-select: none;

  input {
    position: absolute;
    opacity: 0;
    cursor: pointer;

    &:checked ~ .radio-custom {
      background-color: #42b983;
      border-color: #42b983;
      &:after {
        display: block;
      }
    }
  }

  .radio-custom {
    position: relative;
    height: 20px;
    width: 20px;
    background-color: #fff;
    border: 1px solid #ccc;
    border-radius: 50%;
    margin-right: 10px;
    transition: all 0.2s;

    &:after {
      content: "";
      position: absolute;
      display: none;
      top: 5px;
      left: 5px;
      width: 8px;
      height: 8px;
      border-radius: 50%;
      background: white;
    }
  }
}
</style>
