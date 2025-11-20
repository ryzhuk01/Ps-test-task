<script setup lang="ts">
import { ref, watch } from 'vue';
import BaseInput from '../ui/BaseInput.vue';

const props = defineProps<{
  modelValue: string;
}>();

const emit = defineEmits<{
  (e: 'update:modelValue', value: string): void;
  (e: 'search', value: string): void;
}>();

const localValue = ref(props.modelValue);
let timeout: number | null = null;

watch(localValue, (newValue) => {
  emit('update:modelValue', newValue);
  
  if (timeout) clearTimeout(timeout);
  
  timeout = setTimeout(() => {
    emit('search', newValue);
  }, 300) as unknown as number;
});
</script>

<template>
  <div class="search-bar">
    <BaseInput
      v-model="localValue"
      placeholder="Search submissions..."
    />
  </div>
</template>

<style scoped lang="scss">
.search-bar {
  margin-bottom: 1.5rem;
}
</style>
